    async private Task<string> GetUploadResponseBody(UploadOperation operation)
    {
        string responseBody = string.Empty;
        using (var response = operation.GetResultStreamAt(0))
        {
            uint size = (uint)operation.Progress.BytesReceived;
            IBuffer buffer = new Windows.Storage.Streams.Buffer(size);
            var f = await response.ReadAsync(buffer, size, InputStreamOptions.None);
                using (var dr = DataReader.FromBuffer(f))
                {
                    responseBody = dr.ReadString(dr.UnconsumedBufferLength);
                }                
        }
        return responseBody;
    }
