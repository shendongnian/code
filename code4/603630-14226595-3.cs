        int sum = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // int sum = 0; local variable will be set to zero on each timer tick
            label1.Text = sw.Elapsed.ToString(@"hh\:mm\:ss");
            // btw this will not update sum each five seconds
            if (sw.Elapsed.Seconds == 5) 
                sum++; // same as sum = sum +=1;
            label2.Text = sum.ToString();
        }
