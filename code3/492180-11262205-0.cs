    private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
    {       if (numericUpDown1.Value < 1) { numericUpDown1.Value = 1; }
            series = new string[Convert.ToInt16(numericUpDown1.Value)]; 
            int j=series.Length;
            for (int i = 0; i < j; i++) { series[i] = "M" + i.ToString(); }
    }
