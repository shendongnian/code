        private void numericUpDownChartMin_ValueChanged(object sender, EventArgs e)
        {
             numericUpDownChartMax.Minimum = numericUpDownChartMin.Value + 1;
        }
        private void numericUpDownChartMax_ValueChanged(object sender, EventArgs e)
        {
             numericUpDownChartMin.Maximum = numericUpDownChartMax.Value - 1;
        }
