    public class SomeDevice
    {
        private SerialPort _port;
        public SomeDevice(string  serialPortName)
        {
            // do the connection work...
        }
        public void SetVoltage(float voltage)
        {
            port.WriteLine(":VOLT " + voltage.ToSring("N2"));
        }
        public float GetVoltage()
        {
            port.WriteLine(":DEVICE:MEAS:VOLT?");
            return float.Parse(port.ReadLine()); //reading from device
        }
