    protected void btnSMS_Click1(object sender, EventArgs e)
            {
    
    
     String HP = txtHP.Text;
                String URL = "http://api.clickatell.com/http/sendmsg?user=myuser&password=mypassword&api_id=myapi_id&to=";
                String Text = "&text=" + txtSMS.Text;
                string UrlFinal = URL + HP + Text;
    
                string username;
                //Sql Connection to access the database      
                SqlConnection conn6 = new SqlConnection("Data Source=19-17\\sqlexpress;" + "Initial Catalog = Suite2; Integrated Security =SSPI");
                //Opening the Connnection      
                conn6.Open();
                string mySQL;
                username = HttpContext.Current.User.Identity.Name;
                //Insert the information into the database table Login      
                mySQL = "INSERT INTO Table_Message(Username, Message, Title, Startdate, Enddate, SendTo) VALUES('" + username + "','" + txtSMS.Text.Trim() + "','" + txtTitle.Text.Trim() + "','" + txtHP.Text.Trim() + "')";
    
                SqlCommand cmdAdd = new SqlCommand(mySQL, conn6);
                //Execute the sql command      
                cmdAdd.ExecuteNonQuery();
                //Close the Connection 
    
                this.ClientScript.RegisterStartupScript(this.GetType(),
                                            "navigate",
                                            "window.open('" + UrlFinal + "');",
                                            true); 
    
            }
