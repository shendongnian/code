    System.Security.SecureString password = new System.Security.SecureString();
    password.AppendChar('c1');
    //append the all characters of your password, you could probably use a loop and then,
    Process p =new Process();
    p.UseShellExecute = false;
    p.UserName = Environment.UserName;
    p.FileName = file ;
    p.Sassword=password;
    p.Start();
