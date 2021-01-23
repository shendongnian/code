        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(i++<100)progressBar1.Value++;
            if (i == 110)
            {
             splashDone.Set();
             this.Close();
            }
        }
