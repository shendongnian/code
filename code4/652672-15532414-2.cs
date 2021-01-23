    private void button2_Click(object sender, EventArgs e)
    {
        // This is to remove all plots
        zedGraphControl1.GraphPane.CurveList.Clear();
        // GraphPane object holds one or more Curve objects (or plots)
        GraphPane myPane = zedGraphControl1.GraphPane;
        PointPairList spl1 = new PointPairList();
        
        LineItem lineItem = new LineItem("Equation");
        myCurve1.Line.Width = 5.0F;
        myPane.Title.Text = "Graph";
        for (int i = -5; i < 8; i++)
        {
           double y = (i - x1) * (i - x2);
            spl1.Add(i, y);
        }
       // Add cruves to myPane object
        myCurve1 = myPane.AddCurve("Equation", spl1, Color.Blue, SymbolType.None);
         //I add all three functions just to be sure it refeshes the plot.   
        zedGraphControl1.AxisChange();
        zedGraphControl1.Invalidate();
        zedGraphControl1.Refresh();
    }
