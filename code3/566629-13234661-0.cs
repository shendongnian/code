        private void ForceSetBaudRate(string portName, int baudRate)
        {
            if (Type.GetType ("Mono.Runtime") == null) return; //It is not mono === not linux! 
            string arg = String.Format("-F {0} speed {1}",portName , baudRate);
            var proc = new Process
                {
                    EnableRaisingEvents = false,
                    StartInfo = {FileName = @"stty", Arguments = arg}
                };
            proc.Start();
            proc.WaitForExit();
        }
