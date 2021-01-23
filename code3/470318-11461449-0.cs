    class Program
    {
        static void Main(string[] args)
        {
            //check Link-Layer Topology Discover Mapper I/O Driver
            bool result1 = IsProtocalEnabled("Local Area Connection", "ms_lltdio");
            //check Link-Layer Topology Discovery Responder
            bool result2 = IsProtocalEnabled("Local Area Connection", "ms_rspndr");
        }
        private static bool IsProtocalEnabled(string adapter, string protocol)
        {
            var p = new System.Diagnostics.Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nvspbind.exe");
            p.StartInfo.Arguments = string.Format("/o \"{0}\" {1}", adapter, protocol);
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output.Contains("enabled");
        }
    }
