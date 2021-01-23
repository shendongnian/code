    public UserObject(string id)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(SiteConfig.ConnectionString))
            {
                string sSQL = "SELECT [UserName] FROM [aspnet_users] WHERE [UserID] = @UserID";
                using (SqlCommand cm = new SqlCommand(sSQL, cn))
                {
                    if (id.Length == 0)
                        cm.Parameters.AddWithValue("@UserID", Guid.Empty);
                    else if (id == null)
                        cm.Parameters.AddWithValue("@UserID", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@UserID", Guid.Parse(id));
                    cn.Open();
                    using (SqlDataReader rd = cm.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            m_name = rd[0].ToString();
                        }
                        rd.Close();
                    }
                    cn.Close();
                }
            }
        }
        catch (Exception ex)
        {
        }
