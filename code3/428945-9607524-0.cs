    public class PC
    {
        public List<Processor> Processor;
        // Constructor
        public PC()
        {
            this.Processor = new List<Processor>();
        }
        // Method to get all info sequentially
        public void GetAllInfo()
        {
            // These temporary stores fetch WMI data as ManagementObjects
            // Most cases will only need one WMI class.
            ManagementObject[] WMIDataTemp1;
            ManagementObject[] WMIDataTemp2;
            WMIDataTemp1 = DataRetriever.GetWMIData("Win32_Processor");
            foreach (ManagementObject Object in WMIDataTemp1)
            {
                this.Processor.Add(new Processor(Object));
            }
        }
        public void RefreshAll()
        {
            // Delete the lists and start again
            // Another option would be to foreach through the list elements and initialise each object again.
            this.Processor.Clear();
            GetAllInfo();
        }
        public void RefreshVolatileData()
        {
            // Extra function that will do some cool stuff later.
        }
    }
