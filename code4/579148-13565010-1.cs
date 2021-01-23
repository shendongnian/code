    chart1.Series[0].Points.AddXY("Temprature", 78.32);
    chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Color = Color.Red;
    chart1.Series[0].Points.AddXY("VCC", 3.92);
    chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Color = Color.Green;
    chart1.Series[0].Points.AddXY("Light", 333);
    chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Color = Color.Yellow;
