    public abstract class BatteryInfo {
        // int should be replaced with the actual data type of the value
        public abstract int VoltageHigh { get; }
        public abstract int VoltageLow { get; }
        // etc. for each value you need
    }
