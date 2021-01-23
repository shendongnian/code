        public class SlimHomePageData
        {
             private SLIMDataContext dc = new SLIMDataContext(ConfigurationManager.ConnectionStrings["SLIMConnectionString"].ConnectionString);
        .
        .
        .
         public IEnumerable GetOutlookGridDetail(string customerId = "")
        {
            List<WebLicenses> weblicenses = new List<WebLicenses>();
            List<WebApplication> webapplication = new  List<WebApplication>();            
           //remove from here and add at the end of this method 
           //griddetail returnValue = new griddetail(weblicenses, webapplication);          
           SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLIMConnectionString"].ConnectionString);
           SqlCommand cmd = new SqlCommand("selectCustomerDetail", cn);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter param_CustomerID = new SqlParameter("@CustomerID", SqlDbType.VarChar, 10);
           param_CustomerID.Value = customerId;
           cmd.Parameters.Add(param_CustomerID);
           try
           {
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
               if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        WebLicenses newRecord = new WebLicenses();
                        newRecord.WebLicenseName = Convert.ToString(reader["WebLicenseName"]);
                        newRecord.CustomerWebLicensesCount = Convert.ToInt32(reader["CustomerWebLicensesCount"]);
                        weblicenses.Add(newRecord);
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        WebApplication newRecord = new WebApplication();
                        newRecord.WebApplicationName = Convert.ToString(reader["WebApplicationName"]);
                        newRecord.Count = Convert.ToInt32(reader["Count"]);
                        bool never = false;
                        if (reader["Never"] != DBNull.Value)
                        {
                            bool.TryParse(reader["Never"].ToString(), out never);
                        }
                        if (reader["EndDate"] != DBNull.Value)
                        {
                            newRecord.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        }
                        newRecord.Never = never;
                        webapplication.Add(newRecord);
                    }
                }
            reader.Close();
           }
           catch (Exception)
           {
               // returnValue = null;
           }
           finally
           {
               cmd.Dispose();
               if (cn.State == ConnectionState.Open)
               {
                   cn.Close();
               }
           }
               griddetail returnValue = new griddetail(weblicenses, webapplication, webcustomapplication, maintenance, smartcv, histry, doc);
            return returnValue;
           }
          .
           .
          }//closing of my SlimHomePageData class
