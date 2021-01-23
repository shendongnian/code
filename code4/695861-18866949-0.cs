            private void SetUSBSerialPort()
            {
                try
                {
                    usbSerialPort = new USBSerialPort(config.terminal_tcpip_port);
                    usbSerialPort.OnReceiveData += new USBSerialPort.EventOnReceiveData(usbSerialPort_OnReceiveData);
                    usbSerialPort.Start();
                }
                catch (Exception ex)
                {
                    
                }
            }
