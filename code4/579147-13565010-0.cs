    chart1.Series["Temprature"].Points.AddXY(1, 78.32);
    chart1.Series["Temprature"].Points.Add(new DataPoint(2,0){IsEmpty=true});
    chart1.Series["Temprature"].Points.Add(new DataPoint(3,0){IsEmpty=true});
    
    chart1.Series["VCC"].Points.Add(new DataPoint(1,0){IsEmpty=true});
    chart1.Series["VCC"].Points.AddXY(2, 3.92);
    chart1.Series["VCC"].Points.Add(new DataPoint(3,0){IsEmpty=true});
    
    chart1.Series["Light"].Points.Add(new DataPoint(1,0){IsEmpty=true});
    chart1.Series["Light"].Points.Add(new DataPoint(2,0){IsEmpty=true});
    chart1.Series["Light"].Points.AddXY(3, 333);
