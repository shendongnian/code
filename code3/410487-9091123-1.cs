    DirectoryEntry deComputer = new DirectoryEntry("WinNT://JPBASUSF1,computer");
    DirectoryEntry deUser = deComputer.Children.Add("JPB", "user");
    deUser.Invoke("SetPassword", new object[] { "test.2011" }); 
    deUser.Properties["Description"].Add("user $userName");
    deUser.Properties["userflags"].Add(512);
    deUser.Properties["passwordExpired"].Add(1);
    deUser.Properties["LoginScript"].Add("start.cmd");
    deUser.CommitChanges();
