        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s1.BytesToRead > 0)
            {
                //write text to text box
                //e.g. maybe as a start try
                txtDataReceived.Text += s1.ReadExisting();
            }
        }
