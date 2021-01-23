    public class Processor
    {
        // Define properties
        public string Architecture = "N/A";
        public string Availability = "N/A";
        public UInt32 CacheL2 = 0;
        public UInt32 CacheL3 = 0;
        // Overloaded constructor method
        // The one with no arguments does nothing to initialise the class
        // The one with the ManagementObject argument will call GetInfo to arrange the held data into the properties above
        public Processor() { }
        public Processor(ManagementObject wmiProcessor)
        {
            this.GetInfo(wmiProcessor);
        }
        // The main information handler for the classes.
        // This splits out the data in the ManagementObject into the class's own properties
        public void GetInfo(ManagementObject wmiProcessor)
        {
            // If anything fails, the try loop will just end without making a fuss
            // Because of the default values, N/A will be displayed everywhere if something fails here.
            try
            {
                this.Architecture = (string)wmiProcessor["Architecture"];
                this.Availability = (string)wmiProcessor["Availability"];
                this.CacheL2 = (UInt32)wmiProcessor["L2CacheSize"];
                this.CacheL3 = (UInt32)wmiProcessor["L3CacheSize"];
            }
            catch (Exception e)
            {
            }
        }
    }
