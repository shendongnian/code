    using LibUsbDotNet;
    using LibUsbDotNet.DeviceNotify;
    using LibUsbDotNet.Info;
    using LibUsbDotNet.Main;    
                
    SafeSerialPort serialPort;
        
                public SerialPortTest()
                {
                    Connect();
        
                    UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;
                }
        
                private void Connect()
                {
                    string portname = "COM8";
                    serialPort = new SafeSerialPort(portname, 9600);
                    serialPort.DataReceived += port_DataReceived;
                    serialPort.Open(); 
                }
        
                private void ResetConnection()
                {
                    try
                    {
                        serialPort.Write("Any value");
                    }
                    catch (IOException ex)
                    {
                        serialPort.Dispose();
                        serialPort.Close();
                        Task.Factory.StartNew(() =>
                        {
                            PortHelper.TryResetPortByName("COM8");
                        });
                    }
                }
        
        
                void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
                {
                    Console.WriteLine(serialPort.ReadExisting());
                }
        
                public UsbDevice MyUsbDevice;
    
                //Vendor ID etc can be found through enumerating the USB devices
                public UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(0x2341, 0x0001);
                public IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
                private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
                {
                    //if this is your usb device, in my case an Arduino
                    if (e.Object.ToString().Split('\n')[1].Contains("0x2341"))
                    {
                        if (e.EventType == EventType.DeviceArrival)
                        {
                            Connect();
                        }
                        else
                        {
                            ResetConnection();
                        }
                    }
                }
