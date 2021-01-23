        int month = XValues[0].Month;
        var XAxis = Chart4.ChartAreas[0].AxisX;
        DateTime StartMonthPos = XValues[0];
        DateTime EndPos = new DateTime();
        foreach (DateTime Date in XValues)
        {
            EndPos = Date;
            if (Date.Month != month)
            {
               Chart4.ChartAreas[0].AxisX.CustomLabels.Add(StartMonthPos.ToOADate(),
                  EndPos.ToOADate(), StartMonthPos.ToString("MMMM"), 0, LabelMarkStyle.None);
                StartMonthPos = Date;
            }
            month = Date.Month;
        }
        XAxis.CustomLabels.Add(StartMonthPos.ToOADate(), EndPos.ToOADate(),
              StartMonthPos.ToString("MMMM"), 0, LabelMarkStyle.None);
    
