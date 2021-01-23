        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 500;
        }
        private void button1_MouseUp(object sender, MouseEventArgs  e) 
        {
            timer1.Stop();
            this.Text = "moose-Up";
        }
        private void button1_MouseDown(object sender, EventArgs e)
        {
            timer1.Start();
            this.Text = "moose-Down";
            this.richTextBox1.Select();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("r");
            Debug.Print("tickling");
        }
