    using System.Threading;
    ...
    Clipboard.SetImage(bm);   // some code
    distribution_chart.BackColor = Color.Gray;
    Application.DoEvents();   // ensure repaint, may be not needed
    Thread.Sleep(50);
    distribution_chart.BackColor = Color.OldLace;
    ....
