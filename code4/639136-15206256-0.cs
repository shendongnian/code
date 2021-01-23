    ChartArea[] ca = new ChartArea[1];
    Chart1.ChartAreas.CopyTo(ca, 0);
    ChartControl1.ChartAreas.Add(ca[0]);
    Series[] s = new Series[5];
    Chart1.Series.CopyTo(s, 0);
    foreach (Series ss in s)
    {
      if (ss != null)
      {
        ChartControl1.Series.Add(ss);
      }
    }        
    Legend[] l = new Legend[5];
    Chart1.Legends.CopyTo(l, 0);
    foreach (Legend ll in l)
    {
      if (ll != null)
      {
        ChartControl1.Legends.Add(ll);
      }
    }
