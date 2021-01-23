    using (var client = new SshClient("ssh_hostname", "ssh_username", "ssh_password"))
    {
      client.Connect();
      var tunnel = new ForwardedPortLocal("127.0.0.1", 8001, "127.0.0.1", 3306);
      client.AddForwardedPort(tunnel);
      tunnel.Start();
      using (var DB = new DBContext())
      {
        //MySQL interaction here!
        scores = DB.Table
          .Where(x => !String.IsNullOrEmpty(x.SomeField))
          .ToList();
      }
      tunnel.Stop();
    }
