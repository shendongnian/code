    private void chartControl1_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
    {
         // Get the value of your point (Age in your case)
         var pointValue = e.SeriesPoint.Values[0];
         // You can get the argument text using e.SeriesPoint.Argument
         // Set the label text of your point
         e.LabelText = "value is " + pointValue;
    }
