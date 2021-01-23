    var timeSeries = new List<TimeSeries>();  
    using (var reader = cmd.ExecuteReader())
    {
        if (reader.HasRows)
        {
            timeSeries = reader.Cast<IDataRecord>()
                .Select(r => new TimeSeries
                     {
                         MidRate = (double)r["MidRate"],
                         RiskFactorName = (string)r["RiskFactorName"],
                         SeriesDate = (DateTime)r["SeriesDate"]
                     }).ToList();
        }
    }
