    private void btnsend_Click(object sender, EventArgs e)
        {
            using (var sp = new SerialPort("COM4"))
            {
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                sp.WriteLine("AT+CMGS=\"" + "phone no" + "\"" + Environment.NewLine);
                sp.WriteLine("your text message" + (char)26);
            }
        }
