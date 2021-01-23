            SerialPort po = new SerialPort();
            po.PortName = "COM10";
            po.BaudRate = int.Parse("9600");
            po.DataBits = Convert.ToInt32("8");
            po.Parity = Parity.None;
            po.StopBits = StopBits.One;
            po.ReadTimeout = int.Parse("300");
            po.WriteTimeout = int.Parse("300");
            po.Encoding = Encoding.GetEncoding("iso-8859-1");
            po.Open();
            po.DtrEnable = true;
            po.RtsEnable = true;
            //po.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
           // po.Write("ATD01814201013;");
            po.WriteLine("ATD01"+textBoxPhoneNumber.Text+";"+Environment.NewLine);
        }
