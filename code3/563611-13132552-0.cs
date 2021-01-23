        public static void queryDevice()
        {
            SerialPort _serialPort = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            ObservableCollection<string> store= new ObservableCollection<string> { " ", " ", " " };
            string[] query = new string[3] { "t02", "t03", "t04" };
            Thread thread = new Thread(delegate(){Process(store,query,_serialPort);});
            thread.Start();
        }
    
       
    
         public static void Process(ObservableCollection<string> store, string[] query, SerialPort _serialPort)
         {
             while (true)
             {
                 for (int i = 0; i < 3; i++)
                 {
                     string add = SerialCom.returnData(query[i], _serialPort);
                     if (store[i] != add)
                     {
                         store.Add(add);
                     }
                 }
                 Thread.Sleep(300);
             }
         }
