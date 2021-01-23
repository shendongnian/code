        while (dr.Read())
        {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlConn;
                cmd.CommandText = "insert into CPC_Coupons(PortalID, CreatedByUser, CouponCode, ProductID, ExpiresOn, Quantity, Title, FirstName, LastName, Company, Address1, City, Region, Zip, Country, WorkPhone, Email, Campaign, Source, Market, Notes) values(@PortalID, @CreatedByUser, @Coupon, @ProductID, @ExpiresOn, @Quantity, @Title, @FirstName, @LastName, @Company, @Address1, @City, @Region, @Zip, @Country, @WorkPhone, @Email, @Campaign, @Source, @Market, @Notes)";
                cmd.Parameters.Add("@PortalID", SqlDbType.NVarChar).Value = 0;
                cmd.Parameters.Add("@Coupon", SqlDbType.NVarChar).Value = dr[0].ToString();
                cmd.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar).Value = "3517";
                cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = "0";
                cmd.Parameters.Add("@ExpiresOn", SqlDbType.NVarChar).Value = "01/01/2013";
                cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = "100";
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = "Mr.";
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = dr[3].ToString();
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = dr[4].ToString();
                cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = dr[2].ToString();
                cmd.Parameters.Add("@Address1", SqlDbType.NVarChar).Value = dr[5].ToString();
                cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = dr[6].ToString();
                cmd.Parameters.Add("@Region", SqlDbType.NVarChar).Value = dr[7].ToString();
                cmd.Parameters.Add("@Zip", SqlDbType.NVarChar).Value = dr[8].ToString();
                cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = dr[9].ToString();
                cmd.Parameters.Add("@WorkPhone", SqlDbType.NVarChar).Value = dr[10].ToString();
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dr[11].ToString();
                cmd.Parameters.Add("@Campaign", SqlDbType.NVarChar).Value = txtCampaign.Text;
                cmd.Parameters.Add("@Source", SqlDbType.NVarChar).Value = dr[12].ToString();
                cmd.Parameters.Add("@Market", SqlDbType.NVarChar).Value = txtMarketSegment.Text;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = txtNotesToSales.Text;
                cmd.CommandType = CommandType.Text;
                SqlConn.Open();
                cmd.ExecuteNonQuery();
                SqlConn.Close();
            }
