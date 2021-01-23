        chart1.Customize += chart1_Customize;
        void chart1_Customize(object sender, EventArgs e)
        {
            foreach (var label in chart1.ChartAreas[0].AxisX.CustomLabels)
            {
                int xval = int.Parse(label.Text); // get the list index
                int xnewLabel = ((xval - 1) / 75); // change the range
                label.Text = xnewLabel.ToString(); // update to new value
            }
        }
