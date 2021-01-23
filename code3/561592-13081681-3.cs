        List<Email> list = new List<Email>();
        while (rdr.Read())
        {
            Email o = new Email() { Fname=rdr["Fname"], MailFrom=rdr["MailFrom"],
                MailTo=rdr["MailTo"], Subject=rdr["Subject"], Body=rdr["Body"], 
                MailID=Convert.ToInt32(rdr["MailID"]) };
            Console.WriteLine("First Name: {0}", o.Fname);
            Console.WriteLine("MailFrom: {0}", o.MailFrom);
            Console.WriteLine("Mail To: {0}", o.MailTo);
            Console.WriteLine("Subject: {0}", o.Subject);
            Console.WriteLine("Body: {0}", o.Body);
            list.Add(o);
        } 
    
