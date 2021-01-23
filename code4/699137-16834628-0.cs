    public class UserNameList
    { 
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> GetEmpList()
        {
            List<string> emp = new List<string>();
            string QueryString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            using (SqlConnection obj_SqlConnection = new SqlConnection(QueryString))
            {
                using (SqlCommand obj_Sqlcommand = new SqlCommand("Select DISTINCT name as txt from lib_memtable where name like  @SearchText +'%' ", obj_SqlConnection))
                 {
                    obj_SqlConnection.Open();
                    obj_Sqlcommand.Parameters.AddWithValue("@SearchText", Name);
                    SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                    while (obj_result.Read())
                    {
                        emp.Add(obj_result["name"].ToString().TrimEnd());
                    }
                }
            }
            return emp;
        }
    }
