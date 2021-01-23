    private string GetSchemaNodeValues(string SchemaNodeId)
    {
        ...
        var result = data.Tables[0].AsEnumerable().Select(dr => new
        {
            Value = dr["Value"].ToString()
        });
        return JsonConvert.SerializeObject(result);
    }
