      private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
                try
                {
                    SetText(serialPort1.ReadLine());
                }
                catch (Exception ex)
                {
                    SetText(ex.ToString());
                }
            }
