    private void AddControls(ControlCollection page, ArrayList controlList)
    {
        foreach (Control c in page)
        {
            if (c is WebChartControl)
            {
                WebChartControl chart = c as WebChartControl;
                controlList.Add(chart);
            }
            if (c.HasControls())
            {
                AddControls(c.Controls, controlList);
            }
        }
    }
