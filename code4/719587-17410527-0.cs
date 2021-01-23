    bool autoChange = false;
    private void numericUpDownChartMin_ValueChanged(object sender, EventArgs e)
    {
        if (numericUpDownChartMax.Maximum >= numericUpDownChartMin.Value + 1 && !autoChange)
        {
            autoChange = true;
            numericUpDownChartMax.Value = numericUpDownChartMin.Value + 1;
            autoChange = false;
        }
    }
    private void numericUpDownChartMax_ValueChanged(object sender, EventArgs e)
    {
        if (numericUpDownChartMin.Minimum <= numericUpDownChartMax.Value - 1 && !autoChange)
        {
            autoChange = true;
            numericUpDownChartMin.Value = numericUpDownChartMax.Value - 1;
            autoChange = false;
        }
    }
