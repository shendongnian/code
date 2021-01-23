            SerialPort tmp;
            foreach (string str in SerialPort.GetPortNames())
            {
                tmp = new SerialPort(str);
                if (tmp.IsOpen == false)
                {
                    serialPort.PortName = str;
                    try
                    {
                        //open serial port
                        serialPort.Open();
                        serialPort.BaudRate = 9600;
                        serialPort.WriteTimeout = 10;
                        serialPort.ReadTimeout = 10;
                        serialPort.Write("<mccon>");
                        String s = serialPort.ReadTo("\n");
                        if (s == "<connected>")
                        {
                            break;
                        }
                        else
                        {
                            serialPort.Close();
                        }
                    }
                    catch (TimeoutException)
                    {
                        serialPort.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
