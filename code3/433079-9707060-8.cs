    public Promotion retrievePromotion(int promotionID)
    {
        Promotion promo = null;
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnStr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            var queryString = "SELECT PromotionID, PromotionTitle, PromotionURL FROM Promotion WHERE PromotionID=@PromotionID";
            using (var da = new SqlDataAdapter(queryString, connection))
            {
                // you could also use a SqlDataReader instead
                // note that a DataTable does not need to be disposed since it does not implement IDisposable
                var tblPromotion = new DataTable();
                // avoid SQL-Injection
                da.SelectCommand.Parameters.Add("@PromotionID", SqlDbType.Int);
                da.SelectCommand.Parameters["@PromotionID"].Value = promotionID;
                try
                {
                    da.Fill(tblPromotion);
                    if (tblPromotion.Rows.Count != 0)
                    {
                        var promoRow = tblPromotion.Rows[0];
                        promo = new Promotion()
                        {
                            promotionID    = promotionID,
                            promotionTitle = promoRow.Field<String>("PromotionTitle"),
                            promotionUrl   = promoRow.Field<String>("PromotionURL")
                        };
                    }
                }
                catch (Exception ex)
                {
                    // log this exception or throw it up the StackTrace
                    // we do not need a finally-block to close the connection since it will be closed implicitely in an using-statement
                    throw;
                }
            }
        }
        return promo;
    }
