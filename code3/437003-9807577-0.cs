        SmtpClient smtp = new SmtpClient("ipipi.com",25);
        smtp.Credentials = new NetworkCredential(login,password);
        System.Security.Permissions.SecurityAction sa = new System.Security.Permissions.SecurityAction();
        SmtpPermissionAttribute smp = new SmtpPermissionAttribute(sa);
        try{
             smtp.Send(mail);
        }
