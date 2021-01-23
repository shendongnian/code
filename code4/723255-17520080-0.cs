           void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                Thread.Sleep(500);
                SerialPort sp = (SerialPort)sender;
                string data = sp.ReadLine();
                this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
                sp.Close();
            }
