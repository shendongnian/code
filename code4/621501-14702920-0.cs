    decimal? result;
    if (Convert.IsDBNull(dr["AskingPriceFrom"]))
    {
       result= null;
    }
    else
    {
       result = dr.GetDecimal(reader.GetOrdinal("AskingPriceFrom"));
    }
