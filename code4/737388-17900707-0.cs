    public class Zone
    {
        public string Label;
        public short ID;
        private  List<Device> _devices;
        public List<Device> Devices
        {
            get
            {
                return this._devices ?? (this._devices = new List<Device>());
            }
        }
        public Zone(string Label, short ID)
        {
            this.Label = Label;
            this.ID = ID;
        }
        // Added this to see if it would work, it would not.
        public void AddDevice(string Label, string Address, string Type)
        {
            Devices.Add(new Device(Label, Address, Type));
        }
    }
