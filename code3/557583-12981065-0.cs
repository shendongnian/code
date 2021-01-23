    using (ServerManager iisServerManager = new ServerManager())
    {
        foreach (Site site in iisServerManager.Sites)
        {
            foreach (Binding binding in site.Bindings)
            {
                string ipAddress = "*";
                int port = binding.EndPoint.Port;
                string hostHeader = binding.Host;
                binding.BindingInformation = string.Format("{0}:{1}:{2}", ipAddress, port, hostHeader);
            }
            iisServerManager.CommitChanges();
        }
    }
