    public void SendEmails(String esmails)
    {
        //splitting email string 
        var splitted = 
            esmails.Split(new []{System.Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Replace(";", ""));
        var matchings = 
                from s in splitted
                join email in GetEmails on email.EmailAddress equals s
                select new KeyValuePair<string, string>(email.IdentificationNo, email.EmailAddress);
        var myList = matchings.ToList();
    }
