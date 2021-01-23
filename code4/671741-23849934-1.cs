    private void CreateGraph(ZedGraphControl z1)
            {
                myPane = z1.GraphPane;
                if (myPane != null)
                {
                    myPane.CurveList.Clear();
                    myPane.GraphObjList.Clear();
                    myPane.Title.Text = "Histograms";
                    myPane.XAxis.Title.Text = "Bar Number";
                    myPane.YAxis.Title.Text = "Value";
    
                    myPane.XAxis.Scale.MaxAuto = false;
                    myPane.XAxis.Scale.MinAuto = false;
                    myPane.YAxis.Scale.MaxAuto = false;
                    myPane.YAxis.Scale.MinAuto = false;
    
                    myPane.XAxis.Scale.Min = 0;
                    myPane.XAxis.Scale.Max = 255;
                    myPane.YAxis.Scale.Min = 0;
                    myPane.YAxis.Scale.Max = 255;
    
                    PointPairList list = new PointPairList();
    
    
                    for (int i = 0; i < Core.graphValues.Count; i++)
                    {
                        double x = (double)i;
                        double y = (double)Core.graphValues[i];
                        double z = 0;
                        list.Add(x, y, z);
                    }
                    LineItem myCurve = myPane.AddCurve("Top 1000 Averages",
                   list, Color.Red, SymbolType.None);
    
                    if (inv != true)
                    {
                        z1.Invalidate();
                    }
                    z1.AxisChange();
                }
    
            }
