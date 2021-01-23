        decimal previousValue = 0;
        DateTime time = new DateTime(2000, 6, 10, 0, 0, 0);
        bool justChanged = false;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (justChanged)
            {
                justChanged = !justChanged;
                return;
            }
            else
                justChanged = !justChanged;
            if (numericUpDown1.Value < previousValue)
                time = time.AddMinutes(-30);
            else
                time = time.AddMinutes(30);
            numericUpDown1.Value = decimal.Parse(time.ToString("HH,mm"));
            previousValue = numericUpDown1.Value;
        }
