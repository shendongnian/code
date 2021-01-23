    public class Zone
    {
        public string Label;
        public short ID;
        public List<Device> Devices;
      
        public Zone(string Label, short ID) {
            this.Label = Label;
            this.ID = ID;
            this.Devices = new List<Device>();
        }
        // Added this to see if it would work, it would not.
        public void AddDevice(string Label, string Address, string Type) {
            Devices.Add(new Device(Label, Address, Type));
        }            
    }
