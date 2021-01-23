    if (!sensport.IsOpen)
                {
                    foreach (string port in SerialPort.GetPortNames())
                    {
                        sensport.PortName = port;
                        sensport.BaudRate = 9600;
                        MessageBox.Show(port + " is open");
                    }
                    label1.Text = "";
                    try
                    {
                        sensport.Open();
                    }
                    catch (Exception)
                    {
    
                        MessageBox.Show("Please control your connection");
                    }               
                }
