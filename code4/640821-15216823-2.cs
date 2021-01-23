    pane1.MasterPane[0].XAxis.Scale.IsVisible = false;
    pane1.MasterPane[0].XAxis.MajorTic.IsAllTics = false;
    foreach (double val in x_values)
    {
        TextObj text = new TextObj(val.ToString(), pane1.MasterPane[0].YAxis.Scale.Min, val);
        text.Location.AlignH = AlignH.Right;
        text.FontSpec.Border.IsVisible = false;
        text.FontSpec.Fill.IsVisible = false;
        pane1.MasterPane[0].GraphObjList.Add("Mar10"); 
        LineObj line = new LineObj(pane1.MasterPane[0].YAxis.Scale.Min, val, pane1.MasterPane[0].YAxis.Scale.Max, val);
        line.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
        line.Line.Width = 1f;
        pane1.MasterPane[0].GraphObjList.Add(line);
    }
