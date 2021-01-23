     private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan t = dateTimePicker4.Value.ToLocalTime() - dateTimePicker3.Value.ToLocalTime();
            int x = int.Parse(t.Minutes.ToString());
            y = x;
        }
