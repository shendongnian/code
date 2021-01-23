    namespace WebApplication2
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e) {
                //define some regex patterns for validating our data.
                const string PHONEREGEX = @"((\(\d{3}\))|(\d{3}-))\d{3}-\d{4}";
                const string ORDERNUMREGEX = @"\d*";
    
                bool isValid = true;
    
                string phone = Request.QueryString["phone"]; //read phone from querystring.
    
                //validate that arg was provided, and matches our regular expression. this means it contains only numbers and single hyphens
                if(!string.IsNullOrWhiteSpace(phone) && System.Text.RegularExpressions.Regex.IsMatch(phone, PHONEREGEX)){
                    Response.Write(HttpUtility.HtmlEncode(string.Format("The phone number is {0}", phone))); //HTML Encode the value before output, to prevent any toxic markup.
                } else {
                    Response.Write("Phone number not provided.");
                    isValid = false;
                }
    
                string orderStr = Request.QueryString["order"]; //read ordernum from querystring
                long order = long.MinValue;
    
                //validate that order was provided and matches the regex meaning it is only numbers. then it parses the value into 'long order'.
                if(!string.IsNullOrWhiteSpace(orderStr) && System.Text.RegularExpressions.Regex.IsMatch(orderStr, ORDERNUMREGEX) && long.TryParse(orderStr, out order)){
                    Response.Write(HttpUtility.HtmlEncode(string.Format("The order number is {0}", order))); //use 'long order' instead of orderStr.
                } else {
                    Response.Write("Order number not provided.");
                    isValid = false;
                }
    
                //if all arguments are valid, query the DB.
                if (isValid) {
                    Response.Write(GetOrderStatus( phone, order));
                }
                
            }
    
            private static string GetOrderStatus(string phone, long order) {
                string status = "";
    
                //create a connection object
                string connstring = "SERVER=<YOUR MYSQL SERVER>;DATABASE=<YOUR DATABASE>;UID=<YOUR USER>;PASSWORD=<YOUR PASSWORD>-";//this is a connection string for mysql. customize it to your needs.
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connstring); //put your connection string in this constructor call 
               
                //create a SQL command object
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand()) { //use a using clause so resources are always released when done.
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT `Order_Status` FROM `<YOUR TABLE>` WHERE `Order` = @order AND `Phone` = @phone"; //this needs a From statement 
    
                    //add parameters for your command. they fill in the @order and @phone in the sql statement above. customize these to match the data types in your database.
                    cmd.Parameters.Add("order", MySql.Data.MySqlClient.MySqlDbType.Int64,11).Value = order; //do not use @ sign in parameter name
                    cmd.Parameters.Add("phone", MySql.Data.MySqlClient.MySqlDbType.VarChar, 50).Value = phone;
    
                    //execute the command, read the results from the query.
                    cmd.Connection.Open();
                    using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            status = reader.GetString("Order_Status");
                        }
                        cmd.Connection.Close();
                    }
    
                }
                return status;
            }
        }
    }
