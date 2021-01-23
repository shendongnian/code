    string userPwd = "secretPassword";
    System.Security.SecureString pwd = new System.Security.SecureString();
    foreach (char c in userPwd.ToCharArray())
    {
        pwd.AppendChar(c);
    }
    
    System.Diagnostics.ProcessStartInfo inf = new System.Diagnostics.ProcessStartInfo();
    inf.FileName="path to file";
    inf.Domain = "domainname";
    inf.UserName = "desired_user_name";
    inf.Password = pwd;
    
    System.Diagnostics.Process.Start(inf);
