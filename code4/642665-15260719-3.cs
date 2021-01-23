    while (reader.Read())
    {
        ProdData Analysis = new ProdData();
        if (!reader.IsDBNull(0)) Analysis.productId = reader.GetInt32(0);
        if (!reader.IsDBNull(1)) Analysis.productName = reader.GetString(1);
        ProdList.Add(Analysis);
    }
