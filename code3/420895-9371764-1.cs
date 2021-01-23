    using System.Management;
    using System.IO;
            string result = "";
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                var tList = (from n in portnames join p in ports on n equals p["DeviceID"].ToString() select n + " - " + p["Caption"]).ToList();
                foreach (string s in tList)
                {
                    result = result + s;
                }
            }
            MessageBox.Show(result);
