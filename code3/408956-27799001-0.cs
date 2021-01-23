    private void Remove_1899_Label(object sender, EventArgs e)
    {
        Chart msChart = sender as Chart;
        foreach (var chartArea in msChart.ChartAreas)
        {
            foreach (var label in chartArea.AxisX.CustomLabels)
            {
                if (!string.IsNullOrEmpty(label.Text) && label.Text == "1899")
                {
                    label.SetFieldValue("customLabel", true);
                    label.Text = string.Empty;
                }
            }
        }
    }
