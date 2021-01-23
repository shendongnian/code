     [WebMethod]
     public bool sendEmail()
     {
       //mail settings
       //smtp settings
       try 
       { 
            smtp.Send(mail);
            return true;
       }
       catch
       {
           return false;
       }
