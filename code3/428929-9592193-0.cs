    class PC
    {
        public Processor[] Processors;
        public Motherboard Motherboard;
    
        // Constructor
        public PC()
        {
            
            Motherboard = new Motherboard();
        }
    
        // Method to get all info sequentially
        public void GetAllInfo()
        {
            ManagementObject[] WMIData = DataRetriever.GetWMIData("Win32_Processor");
            Processors = new Processor[WMIData.Length-1];
            for (int i = 1; i < WMIData.Length; i++)
                {
                Processors[i-1] = new Processor(WMIData[i-1]); //assuming 0 based                
                }
            
            Motherboard.GetInfo();
        }
    }
    
    class Processor
    {
        public string Architecture;
        public string[] Availability;
        public UInt16[] Cores;
    
        public Processor(ManagementObject WMIData)
        {
            this.Architecture = (string)WMIData["Architecture"];
            this.Availability = (string)WMIData["Availability"];
            this.Cores = (UInt16)WMIData["NumberOfCores"];
        }
    }
