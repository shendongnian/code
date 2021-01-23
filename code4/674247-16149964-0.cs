    foreach (var o in ListObjOfThatClass)
    {
        chart1.Series[0].Points.Add(new DataPoint(o.Id, o.Count1) {
            ToolTip = string.Format("{0}", o.Count2) 
        });
        chart1.Series[1].Points.Add(new DataPoint(o.Id, o.Count2));
    }
