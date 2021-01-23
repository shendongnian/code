            Chart1.Series.ResumeUpdates()
            Chart1.Series[1].Points.Item[0].YValues = Double(1) {MyNewValue, 0}
            Chart1.Series[1].Points[0].Color = Color.Red
            Chart1.DataBind()
            Chart1.Series.Invalidate()
            Chart1.Series.SuspendUpdates()
