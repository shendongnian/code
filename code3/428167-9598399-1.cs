    [DisplayName("Usb")]
    public class UsbSendOut : ISendOut
    {
        public void Send(string data)
        {
            MessageBox.Show("data sent through usb.");
        }
    }
