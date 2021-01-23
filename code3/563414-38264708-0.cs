    //Include VMware C# sdk VMware.VIM dll as reference in your project
    //try to invoke client connection
    VMware.Vim.VimClientImpl client = new VimClientImpl();
    client.Connect(@"VMware_Server_IP/sdk");
    // Login using username/password credentials
    UserSession session = client.Login("USERNAME", "PASSWORD");
              
    //Getting all the virtual machine and the datastore info from the VCenter
    NameValueCollection filter = new NameValueCollection();
    IList vmList = client.FindEntityViews(typeof(VirtualMachine), null, filter, null);`
