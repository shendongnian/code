    public class AutoCompleteService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> GetAutoCompleteData(string PhoneContactName)
        {
            List<string> result = new List<string>();
            string QueryString;
            QueryString = System.Configuration.ConfigurationManager.ConnectionStrings["Admin_raghuConnectionString1"].ToString();
    
            using (SqlConnection obj_SqlConnection = new SqlConnection(QueryString))
            {
                using (SqlCommand obj_Sqlcommand = new SqlCommand("select DISTINCT PhoneContactName from PhoneContacts where PhoneContactName LIKE +@SearchText+'%'", obj_SqlConnection))
                {
                    obj_SqlConnection.Open();
                    obj_Sqlcommand.Parameters.AddWithValue("@SearchText", PhoneContactName);
                    SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                    while (obj_result.Read())
                    {
                        result.Add(obj_result["PhoneContactName"].ToString().TrimEnd());
                    }
                    return result;
                }
            }
        }
    
    }
