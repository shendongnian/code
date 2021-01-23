    chartControl1.SuspendLayout();
    for (int i = 0; i < Line1.Length; i++)
        {
            int y = int.Parse(Line1[i]);
            SeriesPoint pt = new SeriesPoint(i, y);
            chartControl1.Series[0].Points.Add(pt);
        }
    chartControl1.ResumeLayout();
