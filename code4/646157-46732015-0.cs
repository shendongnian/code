    internal class IPAndMac
    {
        public string IP { get; set; }
        public string MAC { get; set; }
    }
    public class IPMacMapper
    {
        private static List<IPAndMac> list;
        private static StreamReader ExecuteCommandLine(String file, String arguments = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = file;
            startInfo.Arguments = arguments;
            Process process = Process.Start(startInfo);
            return process.StandardOutput;
        }
        private static void InitializeGetIPsAndMac()
        {
            if (list != null)
                return;
            var arpStream = ExecuteCommandLine("arp", "-a");
            List<string> result = new List<string>();
            while (!arpStream.EndOfStream)
            {
                var line = arpStream.ReadLine().Trim();
                result.Add(line);
            }
            list = result.Where(x => !string.IsNullOrEmpty(x) && (x.Contains("dynamic") || x.Contains("static")))
                .Select(x =>
                {
                    string[] parts = x.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    return new IPAndMac { IP = parts[0].Trim(), MAC = parts[1].Trim() };
                }).ToList();
        }
        public static string FindIPFromMacAddress(string macAddress)
        {
            InitializeGetIPsAndMac();
            return list.SingleOrDefault(x => x.MAC == macAddress).IP;
        }
        public static string FindMacFromIPAddress(string ip)
        {
            InitializeGetIPsAndMac();
            return list.SingleOrDefault(x => x.IP == ip).MAC;
        }
    }
