    public class Enums
    {
        public enum DeviceType
        {
            Mouse,
            HardDisk,
            CdRom,
        }
        public enum ServerTransportType
        {
            Udp,
            Tcp,
        }
    }
    [Serializable]
    public class Device
    {
        public string Username { get; set; }
        public string AgentName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string PeerURI { get; set; }
        public string SipURI { get; set; }
        public string FQDN { get; set; }
        public Enums.DeviceType Type { get; set; }
        public Enums.ServerTransportType TransportType { get; set; }
        public bool IsInitialized { get; set; }
    }
    public class BinarySerialize
    {
        public void Test()
        {
            var device = new Device();
            device.Username = "userName";
            device.AgentName = "agentName";
            device.Password = "password";
            device.Domain = "domain";
            device.PeerURI = "peerURI";
            device.SipURI = "sipURI";
            device.FQDN = "fqdn";
            device.Type = Enums.DeviceType.HardDisk;
            device.TransportType = Enums.ServerTransportType.Tcp;
            device.IsInitialized = true;
            string fileName = @"C:\temp\device.bin";
            this.Serialize(device, fileName);
            var d = this.Deserialize(fileName);
        }
        public void Serialize(Device device, string fileName)
        {
            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, device);
                stream.Close();
            }
        }
        public Device Deserialize(string fileName)
        {
            var device = new Device();
            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                device = (Device)bformatter.Deserialize(stream);
                stream.Close();
            }
            return device;
        }
