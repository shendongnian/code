    public static void updatePriceBreakRow(string IQPDID, string low, string high, string price, string sPrice, string linenum)
    {
        string sql = "UPDATE ItemQtyPriceDiscTable SET  LowQuantity=@LowQty, HighQuantity=@HighQty, Price=@Price WHERE linenum=@lineNum";
    
        AdoUtil.ACESSQLParameterCollection parameters = new AdoUtil.ACESSQLParameterCollection();
        AdoUtil.ACESSQLParameter param = new AdoUtil.ACESSQLParameter();
    
        param.ParamName = "@IQPDID";
        param.ParamValue =Convert.ToInt32(IQPDID);
        param.ParamDBType = SqlDbType.Int;
        parameters.Add(param);
    
        param.ParamName = "@LowQty";
        param.ParamValue =(float)Convert.ToDouble(low);
        param.ParamDBType = SqlDbType.Float;
        parameters.Add(param);
    
        param.ParamName = "@HighQty";
        param.ParamValue =(float)Convert.ToDouble(high);
        param.ParamDBType = SqlDbType.Float;
        parameters.Add(param);
    
        param.ParamName = "@Price";
        param.ParamValue = (float)Convert.ToDouble(price);
        param.ParamDBType = SqlDbType.Float;
        parameters.Add(param);
    
        param.ParamName = "@SalePrice";
        param.ParamValue =(float)Convert.ToDouble(sPrice);
        param.ParamDBType = SqlDbType.Float;
        parameters.Add(param);
    
        param.ParamName = "@linenum";
        param.ParamValue =Convert.ToInt32(linenum);
        param.ParamDBType = SqlDbType.Int;
        parameters.Add(param);
    
        param.ParamName = "@update";
        param.ParamValue = lastUpdate;
        param.ParamDBType = SqlDbType.VarChar;
        parameters.Add(param);
    
        AdoUtil.ExecuteNonQuery(sql, parameters);
    }
