    hi Please try to run this code. It works in me
      SmtpClient sc = new SmtpClient("smtp.gmail.com");
      NetworkCredential nc = new NetworkCredential("username","password");          //username doesn't include @gmail.com
       sc.UseDefaultCredentials = false;
       sc.Credentials = nc;
       sc.EnableSsl = true;
       sc.Port = 587;
         try
          {
           sc.Send(mm);
          } 
         catch (Exception ex)
        {
       EventLog.WriteEntry("Error Sending", EventLogEntryType.Error);
        }
