    foreach (var o in ListObjOfThatClass)
    {
    	var p1 = new DataPoint();
    	p1.SetValueXY(o.Id, o.Count1);
    	p1.ToolTip = string.Format("{0}", o.Count2);
    	Chart1.Series[0].Points.Add(p1);
    
    	var p2 = new DataPoint();
    	p2.SetValueXY(o.Id, o.Count2);
    	Chart1.Series[1].Points.Add(p2);
    }
