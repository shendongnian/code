    String status = "1";
    SqlConnection conn100 = new SqlConnection("Server=localhost;Integrated                     Security=true;database=WebsiteDatabase");
    conn100.Open();
    SqlCommand cmd100 = conn100.CreateCommand();
    cmd100.CommandText = "select emailaddress from tblUser where apple= '" + status + "'";
        SqlDataReader dr= cmd100.ExecuteReader();
    while(dr.Read())
    {
    string selected100= dr("emailaddress").ToString();
    }
        String emailcontent = "";
        emailcontent = "" + selected1 + "- Highlight: " + selected2;
        String emaillist = "" + selected100;
        //Create a new MailMessage in order to send email
        MailMessage mail = new MailMessage();
        //The recipient of this email
        mail.To.Add("recipient@gmail.com" + emaillist);
    ......................
