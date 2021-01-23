    class Processor
    { 
        private ManagementObject WMIData;
        // obviously you might want to cache this value once it has been retrieved once
        public string Architecture{get{return (string)WMIData["Architecture"];}}
        public string Availability {get{return (string)WMIData["Availability"];}}
        public UInt16 Cores{get{return (UInt16)WMIData["NumberOfCores"]}}
    
        public Processor(ManagementObject WMIData)
        {
            this.WMIData = WMIData;
        }
    }
