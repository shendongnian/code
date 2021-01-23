        public string GetMacByIp( string ip )
        {
            var pairs = this.GetMacIpPairs();
            foreach( var pair in pairs )
            {
                if( pair.IpAddress == ip )
                    return pair.MacAddress;
            }
            throw new Exception( $"Can't retrieve mac address from ip: {ip}" );
        }
        public IEnumerable<MacIpPair> GetMacIpPairs()
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a ";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string cmdOutput = pProcess.StandardOutput.ReadToEnd();
            string pattern = @"(?<ip>([0-9]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-?){6})";
            foreach( Match m in Regex.Matches( cmdOutput, pattern, RegexOptions.IgnoreCase ) )
            {
                yield return new MacIpPair()
                {
                    MacAddress = m.Groups[ "mac" ].Value,
                    IpAddress = m.Groups[ "ip" ].Value
                };
            }
        }
        public struct MacIpPair
        {
            public string MacAddress;
            public string IpAddress;
        }
