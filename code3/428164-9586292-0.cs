    public class UserConfiguredCommunicationModule : ISendOut 
    {
        public UserConfiguredUserModule(SerialPort serial, WirelessModule wireless)
        {}
    
        public void Send(string data)
        {
            if (UserIdentity.Current.PrefersSerial)
                serial.Send(data);
            else
                wireless.Send(data);
        }
    }
