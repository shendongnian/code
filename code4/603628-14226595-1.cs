        int sum = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = sw.Elapsed.ToString(@"hh\:mm\:ss");
            if (sw.Elapsed.Seconds == 5) // not sure why you do this
                sum++; // same as sum = sum +=1;
            label2.Text = sum.ToString();
        }
