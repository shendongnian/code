    private void Call() {
            SerialPort celu = new SerialPort();
            celu.PortName = "COM13"; // You have check what port your phone is using here, and replace it
            celu.Open();
            string cmd = "ATD";  // Here you put your AT command
            string phoneNumber = "784261259"; // Here you put the phone number, for me it worked just with the phone number, not adding any other area code or something like that
            celu.WriteLine(cmd + phoneNumber + ";\r");
            Thread.Sleep(500);
            string ss = celu.ReadExisting();
            if (ss.EndsWith("\r\nOK\r\n"))
            {
                MessageBox.Show("Modem is connected \r Calling : " + phoneNumber);
            }
            celu.Close();
        }
