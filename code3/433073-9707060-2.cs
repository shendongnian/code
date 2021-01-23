    public Promotion retrievePromotion(int promotionID)
    {
        Promotion promo = null;
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnStr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            var queryString = "SELECT PromotionID, PromotionTitle, PromotionURL FROM Promotion WHERE PromotionID=@PromotionID";
            using (var da = new SqlDataAdapter(queryString, connection))
            {
                var tblPromotion = new DataTable(); // you could also use a SqlDataReader instead
                // avoid SQL-Injection
                da.SelectCommand.Parameters.Add("@PromotionID", SqlDbType.Int);
                da.SelectCommand.Parameters["@PromotionID"].Value = promotionID;
                try
                {
                    connection.Open();
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
                    // log this exception and/or throw it up the StackTrace
                    // note that we don't need a finally to close the connection since we're in an using-statement
                    throw;
                }
            }
        }
        return promo;
    }
