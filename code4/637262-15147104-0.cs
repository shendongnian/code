    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    public class SO15147104
    {
        private List<string> HWIDLookup;
        private List<IPAddress> IPAddressLookup;
        public SO15147104()
        {
            HWIDLookup = LoadBlockHWID(new FileInfo(@"c:\testfileHWID.txt"));
            IPAddressLookup = LoadBlockIPAddresses(new FileInfo(
                                                   @"c:\testfileIPAddresses.txt"));
        }
        public bool BlockRequest(IPAddress ip, string HWIDtoCheck)
        {
            if (IPAddressLookup.Contains(ip) &&
                HWIDLookup.Contains(HWIDtoCheck.ToUpperInvariant().Trim()))
            {
                return true;
            }
            return false;
        }
        private List<IPAddress> LoadBlockIPAddresses(FileInfo fi)
        {
            List<IPAddress> result = new List<IPAddress>();
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    IPAddress theIP = IPAddress.Any;
                    string thisLine = sr.ReadLine().Trim();
                    //This should allow IPv6 and IPv4 to be listed 1IP per Line
                    if (IPAddress.TryParse(thisLine, out theIP))
                    {
                        result.Add(theIP);
                    }
                }
            }
            return result;
        }
        private List<string> LoadBlockHWID(FileInfo fi)
        {
            List<string> result = new List<string>();
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine().Trim().ToUpperInvariant());
                }
            }
            return result;
        }
