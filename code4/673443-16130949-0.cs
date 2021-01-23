        DateTime start;
        private void button1_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            AnimateProgBar(12000);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Subtract(start).TotalSeconds.ToString();
            //the rest of your code, starting with "if (pbStatus.Value < 100)"
