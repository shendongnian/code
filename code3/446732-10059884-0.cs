    /// <summary>
    /// Class to manage an adapters total transfered data
    /// </summary>
    public class BandwidthCounter
    {
        /// <summary>
        /// Class to manage an adapters current transfer rate
        /// </summary>
        class MiniCounter
        {
            public uint bytes = 0;
            public uint kbytes = 0;
            public uint mbytes = 0;
            public uint gbytes = 0;
            public uint tbytes = 0;
            public uint pbytes = 0;
            DateTime lastRead = DateTime.Now;
            /// <summary>
            /// Adds bits(total misnomer because bits per second looks a lot better than bytes per second)
            /// </summary>
            /// <param name="count">The number of bits to add</param>
            public void AddBytes(uint count)
            {
                bytes += count;
                while (bytes > 1024)
                {
                    kbytes++;
                    bytes -= 1024;
                }
                while (kbytes > 1024)
                {
                    mbytes++;
                    kbytes -= 1024;
                }
                while (mbytes > 1024)
                {
                    gbytes++;
                    mbytes -= 1024;
                }
                while (gbytes > 1024)
                {
                    tbytes++;
                    gbytes -= 1024;
                }
                while (tbytes > 1024)
                {
                    pbytes++;
                    tbytes -= 1024;
                }
            }
            /// <summary>
            /// Returns the bits per second since the last time this function was called
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                if (pbytes > 0)
                {
                    double ret = (double)pbytes + ((double)((double)tbytes / 1024));
                    ret = ret / (DateTime.Now - lastRead).TotalSeconds;
                    lastRead = DateTime.Now;
                    string s = ret.ToString();
                    if (s.Length > 6)
                        s = s.Substring(0, 6);
                    return s + " Pb";
                }
                else if (tbytes > 0)
                {
                    double ret = (double)tbytes + ((double)((double)gbytes / 1024));
                    ret = ret / (DateTime.Now - lastRead).TotalSeconds;
                    lastRead = DateTime.Now;
                    string s = ret.ToString();
                    if (s.Length > 6)
                        s = s.Substring(0, 6);
                    return s + " Tb";
                }
                else if (gbytes > 0)
                {
                    double ret = (double)gbytes + ((double)((double)mbytes / 1024));
                    ret = ret / (DateTime.Now - lastRead).TotalSeconds;
                    lastRead = DateTime.Now;
                    string s = ret.ToString();
                    if (s.Length > 6)
                        s = s.Substring(0, 6);
                    return s + " Gb";
                }
                else if (mbytes > 0)
                {
                    double ret = (double)mbytes + ((double)((double)kbytes / 1024));
                    ret = ret / (DateTime.Now - lastRead).TotalSeconds;
                    lastRead = DateTime.Now;
                    string s = ret.ToString();
                    if (s.Length > 6)
                        s = s.Substring(0, 6);
                    return s + " Mb";
                }
                else if (kbytes > 0)
                {
                    double ret = (double)kbytes + ((double)((double)bytes / 1024));
                    ret = ret / (DateTime.Now - lastRead).TotalSeconds;
                    lastRead = DateTime.Now;
                    string s = ret.ToString();
                    if (s.Length > 6)
                        s = s.Substring(0, 6);
                    return s + " Kb";
                }
                else
                {
                    double ret = bytes;
                    ret = ret / (DateTime.Now - lastRead).TotalSeconds;
                    lastRead = DateTime.Now;
                    string s = ret.ToString();
                    if (s.Length > 6)
                        s = s.Substring(0, 6);
                    return s + " b";
                }
            }
        }
        private uint bytes = 0;
        private uint kbytes = 0;
        private uint mbytes = 0;
        private uint gbytes = 0;
        private uint tbytes = 0;
        private uint pbytes = 0;
        MiniCounter perSecond = new MiniCounter();
        /// <summary>
        /// Empty constructor, because thats constructive
        /// </summary>
        public BandwidthCounter()
        {
        }
        /// <summary>
        /// Accesses the current transfer rate, returning the text
        /// </summary>
        /// <returns></returns>
        public string GetPerSecond()
        {
            string s = perSecond.ToString() + "/s";
            perSecond = new MiniCounter();
            return s;
        }
        /// <summary>
        /// Adds bytes to the total transfered
        /// </summary>
        /// <param name="count">Byte count</param>
        public void AddBytes(uint count)
        {
            // overflow max
            if ((count * 8) >= Int32.MaxValue)
                return;
            count = 8 * count;
            perSecond.AddBytes(count);
            bytes += count;
            while (bytes > 1024)
            {
                kbytes++;
                bytes -= 1024;
            }
            while (kbytes > 1024)
            {
                mbytes++;
                kbytes -= 1024;
            }
            while (mbytes > 1024)
            {
                gbytes++;
                mbytes -= 1024;
            }
            while (gbytes > 1024)
            {
                tbytes++;
                gbytes -= 1024;
            }
            while (tbytes > 1024)
            {
                pbytes++;
                tbytes -= 1024;
            }
        }
        /// <summary>
        /// Prints out a relevant string for the bits transfered
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (pbytes > 0)
            {
                double ret = (double)pbytes + ((double)((double)tbytes / 1024));
                string s = ret.ToString();
                if (s.Length > 6)
                    s = s.Substring(0, 6);
                return s + " Pb";
            }
            else if (tbytes > 0)
            {
                double ret = (double)tbytes + ((double)((double)gbytes / 1024));
                string s = ret.ToString();
                if (s.Length > 6)
                    s = s.Substring(0, 6);
                return s + " Tb";
            }
            else if (gbytes > 0)
            {
                double ret = (double)gbytes + ((double)((double)mbytes / 1024));
                string s = ret.ToString();
                if (s.Length > 6)
                    s = s.Substring(0, 6);
                return s + " Gb";
            }
            else if (mbytes > 0)
            {
                double ret = (double)mbytes + ((double)((double)kbytes / 1024));
                string s = ret.ToString();
                if (s.Length > 6)
                    s = s.Substring(0, 6);
                return s + " Mb";
            }
            else if (kbytes > 0)
            {
                double ret = (double)kbytes + ((double)((double)bytes / 1024));
                string s = ret.ToString();
                if (s.Length > 6)
                    s = s.Substring(0, 6);
                return s + " Kb";
            }
            else
            {
                string s = bytes.ToString();
                if (s.Length > 6)
                    s = s.Substring(0, 6);
                return s + " b";
            }
        }
    }
