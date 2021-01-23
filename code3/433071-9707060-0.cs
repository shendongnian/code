    public Promotion retrievePromotion(int promotionID)
    {
        Promotion promo = null;
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnStr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            var queryString = "SELECT PromotionID, PromotionTitle, PromotionURL FROM Promotion WHERE PromotionID=@PromotionID";
            using (var da = new SqlDataAdapter(queryString, connection))
            {
                var tblPromotion = new DataTable(); // you could also use a Sqldatareader
                da.SelectCommand.Parameters.AddWithValue("@PromotionID", promotionID);
                try
                {
                    connection.Open();
                    da.Fill(tblPromotion);
                    if (tblPromotion.Rows.Count != 0)
                    {
                        promo = new Promotion()
                        {
                            promotionID = promotionID,
                            promotionTitle = tblPromotion.Rows[0].Field<String>("PromotionURL"),
                            promotionUrl = tblPromotion.Rows[0].Field<String>("PromotionURL")
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
