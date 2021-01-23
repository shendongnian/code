    public abstract class Battery
    {
        public string Information { get; set; }
        public float Cell1 { get {return GetValue(Cell1Low, Cell1High) / 1000.0f;} }
        public float Cell2 { get {return GetValue(Cell2Low, Cell2High) / 1000.0f;} }
        public float Cell3 { get {return GetValue(Cell3Low, Cell3High) / 1000.0f;} }
        public float Cell4 { get {return GetValue(Cell4Low, Cell4High) / 1000.0f;} }
        public float Voltage { get {return GetValue(VoltageLow, VoltageHigh);} }
        public int DC { get {return GetValue(DCLow, DCHigh);} }
        public int FCC { get {return GetValue(FCCLow, FCCHigh);} }
        //public bool ChargeIC { get {return } }
        //public int StartCharge { get {return } }
        //public int CurrentCharge { get {return } }
        public bool Exists { get {return GetValue(PowerSource) != 0xFF} }
        public int FCCPercent { get {return ((FCC * 100) / DC);} }
        /// <summary>
        /// Gets a value depending on the Embedded controller
        /// </summary>
        /// <param name="low">The low byte command to process</param>
        /// <param name="high">The high byte command to process</param>
        /// <returns></returns>
        private int GetValue(ushort low, ushort high)
        {
            //Use Embedded controller to get said value
            //ECPort.ReadEC(command);
            //Testing Purposeses
            var lowValue = ECPort.ReadEC(low);
            var highValue = ECPort.ReadEC(high);
            return (int)((highValue << 8) + lowValue);
        }
        private int GetValue(ushort command)
        {
            return (int)ECPort.ReadEC(command);
        }
        public abstract ushort PowerSource {get;}
        public abstract ushort Charge{get;}
        public abstract ushort RSOC{get;}
        public abstract ushort DCLow{get;}
        public abstract ushort DCHigh{get;}
        public abstract ushort FCCLow{get;}
        public abstract ushort FCCHigh{get;}
        public abstract ushort MaxError{get;}
        public abstract ushort Cell1Low{get;}
        public abstract ushort Cell1High{get;}
        public abstract ushort Cell2Low{get;}
        public abstract ushort Cell2High{get;}
        public abstract ushort Cell3Low{get;}
        public abstract ushort Cell3High{get;}
        public abstract ushort Cell4Low { get; }
        public abstract ushort Cell4High { get; }
        public abstract ushort VoltageLow{get;}
        public abstract ushort VoltageHigh{get;}
        public abstract ushort ChargeCurrentLow{get;}
        public abstract ushort ChargeCurrentHigh{get;}
        public abstract ushort ChargeIC{get;}
    }
