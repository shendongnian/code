    class Program
    {
        static void Main(string[] args)
        {
            var services = ReadServicesFile();
            // For example, I want to find information about port 443 of TCP service
            var port443Info = services.FirstOrDefault(s => s.Port == 443 && s.Type.Equals("tcp"));
            if (port443Info != null)
            {
                Console.WriteLine("TCP Port = {0}, Service name = {1}", port443Info.Port, port443Info.Name);
            }
        }
        static List<ServiceInfo> ReadServicesFile()
        {
            var sysFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
            if (!sysFolder.EndsWith("\\"))
                sysFolder += "\\";
            var svcFileName = sysFolder + "drivers\\etc\\services";
            var lines = File.ReadAllLines(svcFileName);
            var result = new List<ServiceInfo>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line) || line.StartsWith("#"))
                    continue;
                var info = new ServiceInfo();
                var index = 0;
                // Name
                info.Name = line.Substring(index, 16).Trim();
                index += 16;
                // Port number and type
                var temp = line.Substring(index, 9).Trim();
                var tempSplitted = temp.Split('/');
                info.Port = ushort.Parse(tempSplitted[0]);
                info.Type = tempSplitted[1].ToLower();
                result.Add(info);
            }
            return result;
        }
    }
