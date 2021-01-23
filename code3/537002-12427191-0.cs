    public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
        }
        PointPairList userClickrList = new PointPairList();
        LineItem userClickCurve = new LineItem("userClickCurve");
        private void zedGraphControl1_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of Graph Pane
            GraphPane myPane = zedGraphControl1.GraphPane;
            // x & y variables to store the axis values
            double xVal;
            double yVal;
            // Clear the previous values if any
            userClickrList.Clear();
            myPane.Legend.IsVisible = false;
            // Use the current mouse locations to get the corresponding 
            // X & Y CO-Ordinates
            myPane.ReverseTransform(e.Location, out xVal, out yVal);
            // Create a list using the above x & y values
            userClickrList.Add(xVal, myPane.YAxis.Scale.Max);
            userClickrList.Add(xVal, myPane.YAxis.Scale.Min);
            // Add a curve
            userClickCurve = myPane.AddCurve(" ", userClickrList, Color.Red, SymbolType.None);
            zedGraphControl1.Refresh();
        }
      
                       
