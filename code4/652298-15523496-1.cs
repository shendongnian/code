    try
    {
        da=new SqlDataAdapter("SELECT TradeNo, Buy_Sell, TradeQty, Market_Price FROM tradeFile", conn);
        DataSet ds=new DataSet();
        da.Fill(ds);
        gvTrade.dataSource = ds.Tables[0].AsEnumerable()
                 .Select(d => new 
                 {
                     TradeNo = d.Field<int>("TradeNo"),
                     Buy_Sell = d.Field<int>("Buy_Sell") == 1 ? "Buy" : "Sell",
                     TradeQty = d.Field<int>("TradeQty"),
                     Market_Price = d.Field<double>("MarketPrice")
                 }); 
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
