    public class Preloader : System.Web.Hosting.IProcessHostPreloadClient
    {
        public void Preload(string[] parameters)
        {
            var uris = System.Configuration.ConfigurationManager
                             .AppSettings["AdditionalStartupUris"];
            StartupApplication(AllUris(uris));
        }
        public void StartupApplication(IEnumerable<Uri> uris)
        {
            new System.Threading.Thread(o =>
            {
                System.Threading.Thread.Sleep(500);
                foreach (var uri in (IEnumerable<Uri>)o) {
                    var client = new System.Net.WebClient();
                    client.DownloadStringAsync(uris.First());
                }
            }).Start(uris);
        }
        public IEnumerable<Uri> AllUris(string userConfiguration)
        {
            if (userConfiguration == null)
                return GuessedUris();
            return AllUris(userConfiguration.Split(' ')).Union(GuessedUris());
        }
        private IEnumerable<Uri> GuessedUris()
        {
            string path = System.Web.HttpRuntime.AppDomainAppVirtualPath;
            if (path != null)
                yield return new Uri("http://localhost" + path);
        }
        private IEnumerable<Uri> AllUris(params string[] configurationParts)
        {
            return configurationParts
                .Select(p => ParseConfiguration(p))
                .Where(p => p.Item1)
                .Select(p => ToUri(p.Item2))
                .Where(u => u != null);
        }
        private Uri ToUri(string value)
        {
            try {
                return new Uri(value);
            }
            catch (UriFormatException) {
                return null;
            }
        }
        private Tuple<bool, string> ParseConfiguration(string part)
        {
            return new Tuple<bool, string>(IsRelevant(part), ParsePart(part));
        }
        private string ParsePart(string part)
        {
            // We expect IPv4 or MachineName followed by |
            var portions = part.Split('|');
            return portions.Last();
        }
        private bool IsRelevant(string part)
        {
            var portions = part.Split('|');
            return
                portions.Count() == 1 ||
                portions[0] == System.Environment.MachineName ||
                HostIpAddresses().Any(a => a == portions[0]);
        }
        private IEnumerable<string> HostIpAddresses()
        {
            var adaptors = System.Net.NetworkInformation
                                 .NetworkInterface.GetAllNetworkInterfaces();
            return adaptors
                    .Where(a => a.OperationalStatus == 
                                System.Net.NetworkInformation.OperationalStatus.Up)
                    .SelectMany(a => a.GetIPProperties().UnicastAddresses)
                    .Where(a => a.Address.AddressFamily == 
                                System.Net.Sockets.AddressFamily.InterNetwork)
                    .Select(a => a.Address.ToString());
        }
    }
