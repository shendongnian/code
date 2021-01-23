    double[] array1 = { 2.8, 4.4, 6.5, 8.3, 3.6, 5.6, 7.3 };
    double[] array2 = { 2.0, 4.0, 6.1, 7.8, 2.5, 5.0, 6.2 };
    
    chart1.Series.Add("Series1");
    chtStudentResult.Series["Series1"].Points.DataBindY(array1);
    chtStudentResult.Series.Add("Series2");
    chtStudentResult.Series["Series2"].Points.DataBindY(array2);
