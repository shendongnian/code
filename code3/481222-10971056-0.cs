    public partial class SeenSMS : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ....
            string connectionString = "Data Source=DSOFT\DOMZ;Initial Catalog=Vilt;UserID=sa;Password=sa123";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM TableName WHERE id='" +user_id +"', con))
                using (SqlDataReader reader = command.ExecuteReader())
    	        {
                    while (reader.Read())
                    {
                        response.Write(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
    	        }
            }
            ....
        }
    }
