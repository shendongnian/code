    private void ZedGraph_MouseMove(object sender, MouseEventArgs e)
            {
                double x, y;
                ZedGraph.GraphPane.ReverseTransform(e.Location, out x, out y);
    
                #region crosshair
    
                if (x < ZedGraph.GraphPane.XAxis.Scale.Min ||
                    x > ZedGraph.GraphPane.XAxis.Scale.Max ||
                    y < ZedGraph.GraphPane.YAxis.Scale.Min ||
                    y > ZedGraph.GraphPane.YAxis.Scale.Max
                    )//out of the bounds
                {
                    ZedGraph_MouseLeave(new object(), new EventArgs());
                }
                else//ok draw
                {
    
                    if (CrossHairX != null && CrossHairY != null)
                    {
                        ZedGraph.GraphPane.GraphObjList.Remove(xHairOld);
                        ZedGraph.GraphPane.GraphObjList.Remove(yHairOld);
                    }
    
                    LineObj xHair = new LineObj(ZedGraph.GraphPane.XAxis.Scale.Min, y, ZedGraph.GraphPane.XAxis.Scale.Max, y);
                    LineObj yHair = new LineObj(x, ZedGraph.GraphPane.YAxis.Scale.Min, x, ZedGraph.GraphPane.YAxis.Scale.Max);
    
                    ZedGraph.GraphPane.GraphObjList.Add(xHair);
                    xHairOld = xHair;
    
                    ZedGraph.GraphPane.GraphObjList.Add(yHair);
                    yHairOld = yHair;
    
                    CrossHairY = y;
                    CrossHairX = x;
    
    
                    ZedGraph.Refresh();
                }
    
                #endregion 
        }
