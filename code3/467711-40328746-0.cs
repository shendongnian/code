    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
            {
                if (InvokeRequired)     //<-- Makes sure the function is invoked to work properly in the UI-Thread
                    BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));     //<-- Function invokes itself
                else
                {
                    int dataLength = _serialPort.BytesToRead;
                    byte[] data = new byte[dataLength];
                    int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                    if (nbrDataRead == 0)
                        return;
                    string str = System.Text.Encoding.UTF8.GetString(data);
                    textBox1.Text = str.ToString();
                }
            }
