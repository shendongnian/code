    ProcessStartInfo processInfo = new ProcessStartInfo(@"D:\Rpts\SSIS_WeeklyFlash_AAF_1.bat");
    processInfo.CreateNoWindow = true;
    processInfo.UseShellExecute = false;
    processInfo.Domain= "MyCompanyDomain";
    processInfo.UserName = "username";
    //Secure string is an odd beast, so you need something like this:
    SecureString ss = new SecureString();
    string password = "p@$$w0rd";
    foreach (char c in password)
    {
      ss.AppendChar(c);
    }
    processInfo.Password = ss;
    ...
