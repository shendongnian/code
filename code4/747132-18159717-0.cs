    public class CustInfo {
 	public string Email {get; set;}
 	public string Name 	{get; set;}
 	public string Balance {get; set;}
    }
    protected void searchEmail ()
    {
     MySqlConnection con = new MySqlConnection("server=localhost;userid=root;password=;database=obsystem");
     con.Open();
     MySqlCommand cmd = new MySqlCommand("SELECT cusEmail, cusName, balance from monthlytracker AND MONTH(paymentDate)='" + mm + "' AND YEAR(paymentDate)='" + year + "'AND status='" + Unpaid + "'",con);
     MySqlDataReader myDataReader = cmd.ExecuteReader();
     List<CustInfo> list_emails = new List<CustInfo>();
     CustInfo customer;
     while (myDataReader.Read())
        {
            list_emails.Add(new CustInfo {
                              Email = myDataReader.GetValue(0).ToString(),
                              Name =  myDataReader.GetValue(1).ToString(),
                              Balance = myDataReader.GetValue(2).ToString() 
                            });
        }
        con.Close(); //Close connection 
        foreach (CustInfo customer in list_emails)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(customer.Email);
            mail.Subject = "Welcome to C#";
            mail.From = new MailAddress("");
            mail.Body = "Test";
            
            // add the values from the customer object to your mail => fe: mail.Body.Replace("$$name$$", customer.Name);
            SmtpClient smtp = new SmtpClient("SMTP Server");
            smtp.Send(mail);
     }
    }
