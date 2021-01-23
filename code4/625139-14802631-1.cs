        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "I will vanish in 5 sec";
            var timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += (o, args) => label1.Text = "";
            timer.Start();
        }
