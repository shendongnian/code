    public class DeviceASerialPort{
        public DeviceASerialPort{
            // the parameter below may be self-defined instead of passed
            this.SerialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            SerialPort.DataReceived += SerialPort_DataReceived;
        }
        private SerialPort;
        //event delegation here (i forgot how to declare delegation
        // let's say the name is also DataReceived
    
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //null guard
            DataReceived(
                sth=> {
                    //custom operation here
                    return sth;
                }
                , sender
                , e);
        }
    }
