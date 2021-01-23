    class Program
    {
        static SynAPICtrl api = new SynAPICtrl();
        static SynDeviceCtrl device = new SynDeviceCtrl();
        static SynPacketCtrl packet = new SynPacketCtrl();
        static int deviceHandle;
        static int counter;
        
        static void Main(string[] args)
        {   
            api.Initialize();
            api.Activate();
            //select the first device found
            deviceHandle = api.FindDevice(SynConnectionType.SE_ConnectionAny, SynDeviceType.SE_DeviceTouchPad, -1);
            device.Select(deviceHandle);
            device.Activate();
            device.OnPacket += SynTP_Dev_OnPacket;
            Console.ReadLine();
        }
        static private void SynTP_Dev_OnPacket()
        {
            var result = device.LoadPacket(packet);
            SynFingerFlags fingerState;
            if(Enum.TryParse(packet.FingerState.ToString(), out fingerState))
            {
                if(fingerState.HasFlag(SynFingerFlags.SF_FingerTap3))
                {
                    Console.WriteLine($"Tapped {counter++}");
                }
            }
        }
    }
