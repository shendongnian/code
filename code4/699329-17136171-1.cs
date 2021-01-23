    var rc = new AxMsRdpClient7NotSafeForScripting();
    rc.Dock = DockStyle.Fill;
    this.Controls.Add(rc);
    rc.RemoteProgram.RemoteProgramMode = true;
    // ServerStartProgram can only be called on an open session; wait for connected until calling
    rc.OnConnected += (_1, _2) => { rc.RemoteProgram.ServerStartProgram(@"%SYSTEMROOT%\notepad.exe", "", "%SYSTEMROOT%", true, "", false); };
    rc.Server = "server.name";
    rc.UserName = "domain\\user";
    // needed to allow password
    rc.AdvancedSettings7.PublicMode = false;
    rc.AdvancedSettings7.ClearTextPassword = "password";
    // needed to allow dimensions other than the size of the control
    rc.DesktopWidth = SystemInformation.VirtualScreen.Width;
    rc.DesktopHeight = SystemInformation.VirtualScreen.Height;
    rc.AdvancedSettings7.SmartSizing = true;
    rc.Connect();
