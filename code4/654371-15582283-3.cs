    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ComputerInfo.Models
    {
        public class DiskInfo
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public string UsedSpace { get; set; }
            public string PercentUsed { get; set; }
            public string FileSystem { get; set; }
        }
    }
