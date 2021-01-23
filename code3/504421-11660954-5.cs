    public ICollection<string> GenerateCodes(int numberOfCodes)
    {
        var result = new List<string>(numberOfCodes);
        while (result.Count < numberOfCodes)
        {
            var batchSize = Math.Min(_batchSize, numberOfCodes - result.Count);
            var batch = Enumerable.Range(0, batchSize)
                .Select(x => GenerateRandomCode());
            var oldResultCount = result.Count;
                
            result.AddRange(FilterAndSecureBatch(batch));
            var filteredBatchSize = result.Count - oldResultCount;
            var collisionRatio = ((double)batchSize - filteredBatchSize) / batchSize;
            // Automatically increment length of random codes if collisions begin happening too frequently
            if (collisionRatio > _collisionThreshold)
                CodeLength++;
        }
        return result;
    }
    private IEnumerable<string> FilterAndSecureBatch(IEnumerable<string> batch)
    {
        using (var command = _connection.CreateCommand())
        {
            command.CommandText = _sqlQuery; // the concurrency-safe query listed above
            var metaData = new[] { new SqlMetaData("Code", SqlDbType.NVarChar, 8) };
            var param = command.Parameters.Add("@batch", SqlDbType.Structured);
            param.TypeName = "dbo.VoucherCodeList";
            param.Value = batch.Select(x =>
            {
                var record = new SqlDataRecord(metaData);
                record.SetString(0, x);
                return record;
            });
            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    yield return reader.GetString(0);
        }
    }
