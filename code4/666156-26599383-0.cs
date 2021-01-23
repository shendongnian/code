    var siteName = "Default Web Site";
    var appPath = "MyWebApplication";
    var serverManager = new ServerManager();
    var site = serverManager.Sites[siteName];
    appPath = appPath.StartsWith("/") ? appPath : "/" + appPath;
    var app = site.Applications[appPath];
    var urls = new List<string>();
    foreach (var binding in site.Bindings)
    {
        var sb = new StringBuilder();
        sb.Append(binding.Protocol);
        sb.Append("://");
        if (!string.IsNullOrWhiteSpace(binding.Host))
        {
            sb.Append(binding.Host);
        }
        else
        {
            if (Equals(binding.EndPoint.Address, IPAddress.Any))
            {
                sb.Append("localhost");
            }
            else
            {
                sb.Append(binding.EndPoint.Address);
            }
            if (binding.EndPoint.Port != 80)
            {
                sb.Append(":");
                sb.Append(binding.EndPoint.Port);
            }
        }
        sb.Append(app.Path);
        urls.Add(sb.ToString());
    }
