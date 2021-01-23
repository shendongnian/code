     using (System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort("COM1"))
            {
                port.Open();
                port.WriteLine("AT+CUSD=0,\"");
                var result = port.ReadLine();               
            }
