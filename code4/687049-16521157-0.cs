    PointPairList warmUpList = new PointPairList();
        LineItem warmUpCurve = new LineItem("warmUpCurve");
        PointPairList coolingDownList = new PointPairList();
        LineItem coolingDownCurve = new LineItem("coolingDownCurve");
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create an instance of Graph Pane
            GraphPane myPane = zedGraphControl1.GraphPane;
            // x & y variables to store the axis values
            double xVal;
            double yVal;
            // Clear the previous values if any
            warmUpList.Clear();
            coolingDownList.Clear();
            myPane.Legend.IsVisible = false;
            // Create a list using the above x & y values
            warmUpList.Add(myPane.XAxis.Scale.Min + myPane.XAxis.Scale.MajorStep*1.5 , myPane.YAxis.Scale.Max);
            warmUpList.Add(myPane.XAxis.Scale.Min + myPane.XAxis.Scale.MajorStep * 1.5, myPane.YAxis.Scale.Min);
            coolingDownList.Add(myPane.XAxis.Scale.Max - myPane.XAxis.Scale.MajorStep * 1.5, myPane.YAxis.Scale.Max);
            coolingDownList.Add(myPane.XAxis.Scale.Max - myPane.XAxis.Scale.MajorStep * 1.5, myPane.YAxis.Scale.Min);
            // Add the curves
            warmUpCurve = myPane.AddCurve(" ", warmUpList, Color.Red, SymbolType.None);
            coolingDownCurve = myPane.AddCurve(" ", coolingDownList, Color.Red, SymbolType.None);
            TextObj WarmUpTextObj = new TextObj("Warm Up", myPane.XAxis.Scale.Min + myPane.XAxis.Scale.MajorStep, myPane.YAxis.Scale.Max - myPane.YAxis.Scale.MajorStep);
            TextObj RunningTextObj = new TextObj("Running Test", myPane.XAxis.Scale.Max/2, myPane.YAxis.Scale.Max - myPane.YAxis.Scale.MajorStep);
            TextObj CoolingDownTextObj = new TextObj("Cooling Down", myPane.XAxis.Scale.Max - myPane.XAxis.Scale.MajorStep, myPane.YAxis.Scale.Max - myPane.YAxis.Scale.MajorStep);
            myPane.GraphObjList.Add(WarmUpTextObj);
            myPane.GraphObjList.Add(RunningTextObj);
            myPane.GraphObjList.Add(CoolingDownTextObj);
            zedGraphControl1.Refresh();
        }
