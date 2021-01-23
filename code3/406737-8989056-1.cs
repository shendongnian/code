    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connString"]))
            using (var command = new SqlCommand("select col1, col2 from table1 where id = @id", connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int, 3).Value = 1;
                connection.Open();
    
                using (var reader = command.ExecuteReader())
                {
                    var sb = new StringBuilder();
                    while (reader.Read())
                    {
                        sb.Append(reader.GetString(reader.GetOrdinal("col1")));
                    }
                    Div1.InnerHtml = sb.ToString();
                }
            }
        }
    }
