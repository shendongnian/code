    using System;
    using System.Collections.Generic;
    class VoltageBoardChannel
    {
        public string ChannelName { get; set; }
        public bool IsAvailable { get; set; }
    }
    static class Program {
        static void Main()
        {
            List<VoltageBoardChannel> selectedChannels = null;
    
            List <VoltageBoardChannel> redhookChannels = new List<VoltageBoardChannel>
            {
                new VoltageBoardChannel { ChannelName = "", IsAvailable = false},
                new VoltageBoardChannel { ChannelName = "VDD_IO_AUD", IsAvailable = true},
                new VoltageBoardChannel { ChannelName = "VDD_CODEC_AUD", IsAvailable = true},
                new VoltageBoardChannel { ChannelName = "VDD_DAL_AUD", IsAvailable = true},
                new VoltageBoardChannel { ChannelName = "VDD_DPD_AUD", IsAvailable = true},
                new VoltageBoardChannel { ChannelName = "VDD_PLL_AUD", IsAvailable = true}            
            };
    
            string redhookboardname = "S1010012";
            string redhookboardnameCase = "s1010012";
    
            // string.Equals(a,b,...) rather than a.Equals(b, ...) avoids
            // potential issues when "a" is null
            if (string.Equals(redhookboardnameCase, redhookboardname,
                StringComparison.InvariantCultureIgnoreCase))
            {
                // set selectedChannels to the **same** list:
                selectedChannels = redhookChannels;
                
                // or if we wanted a filtered list (same VoltageBoardChannel
                // objects, but a different list instance)
                selectedChannels = redhookChannels.FindAll(x => x.IsAvailable);
            }
        }
    }
