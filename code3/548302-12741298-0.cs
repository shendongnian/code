    tmr.Interval = 6;
    tmr.Tick += new EventHandler(tmr_Tick);
    tmrActive = true;
    tmr.Start();
    void tmr_Tick(object sender, EventArgs e)
    {
       DrawPoint(zedGraphControl1, points, num);   //points is an PointPair array of length num with the new points that i want to add to my Curves(1 point for each Curve)      
       zedGraphControl1.AxisChange();
       zedGraphControl1.Refresh();
       if (Start.Enabled == false) Freeze.Enabled = true;
    }
    private void DrawPoint(ZedGraphControl zgc, PointPair[] p, int num)
        {
            GraphPane myPane = zgc.GraphPane;
 
            if (myPane.CurveList.Count < num)
            {
                DrawCurves(zgc, num);
            }
            for (int i = 0; i < num; i++)
            {
                myPane.CurveList[i].AddPoint(p[i]);
            }
            actPos = p[0].X;
            mResize(zgc, actPos);
        }
