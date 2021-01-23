    private static void CreateGraph3(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane pane = zgc.GraphPane;
            // Set the Titles
            pane.Title.Text = "Sorting";
            //Clear current values
            pane.CurveList.Clear();
            // histogram high
            double[] values = new double[n];
            //fill values
            for (int i = 0; i < n; i++)
            {
                values[i] = A1[i]; //A1 is an array that is currently sort
            }
            //create histogram
            BarItem curve = pane.AddBar("Elements", null, values, Color.Blue);
            pane.BarSettings.MinClusterGap = 0.0F; //set columns references
            // update axis
            zgc.AxisChange();
            // update graph
            zgc.Invalidate();
        }
