    try
            {
                serialPort.DtrEnable = false;
                serialPort.RtsEnable = false;
                serialPort.DataReceived -= serialPort_DataReceived;
                Thread.Sleep(200);
                if (serialPort.IsOpen == true)
                {
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
