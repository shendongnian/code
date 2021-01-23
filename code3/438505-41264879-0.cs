        SerialPort SendingPort=null;
        public string TerminateUssdSession()
        {
                InitializePort();
           
                //// generate terminate command for modem
                string cmd = "";
                cmd = "AT+CUSD=2\r";
                // send cmd to modem
                OpenPort();
                SendingPort.Write(cmd);
                Thread.Sleep(500);
                string response = SendingPort.ReadExisting();
                return response;
        }
        private void InitializePort()
        {
            if (SendingPort == null)
            {
                SendingPort = new SerialPort();
                SendingPort.PortName = PortName;//put port name e.g COM5
                SendingPort.BaudRate = 112500;
                SendingPort.Parity = Parity.None;
                SendingPort.DataBits = 8;
                SendingPort.StopBits = StopBits.One;
                SendingPort.Handshake = Handshake.None;
                SendingPort.ReadTimeout = 500;
            }
        }
        private void OpenPort()
        {
            if (!SendingPort.IsOpen)
            {
                SendingPort.Open();
            }
        }
