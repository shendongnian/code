        static void Main(string[] args)
        {
            var command = "cmd.exe";
            var environmentVariables = new System.Collections.Hashtable();
            environmentVariables.Add("some", "value");
            environmentVariables.Add("someother", "value");
            var filename = Path.GetTempFileName() + ".cmd";
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine("@echo off");
            foreach (DictionaryEntry entry in environmentVariables)
            {
                sw.WriteLine("set {0}={1}", entry.Key, entry.Value);
            } 
            sw.WriteLine("start /w {0}", command);
            sw.Close();
            var psi = new ProcessStartInfo(filename) {
                UseShellExecute = true, 
                Verb="runas"
            };
            var ps =  Process.Start(psi);
            ps.WaitForExit();
            File.Delete(filename);
        }
