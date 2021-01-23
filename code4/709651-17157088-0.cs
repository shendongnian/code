    using OxyPlot.Series;
    using OxyPlot;
    
    namespace Algorithm1
    {
 
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<DataPoint> S1 = new List<DataPoint> ();
                List<DataPoint> S2 = new List<DataPoint>();
                List<DataPoint> NS1 = new List<DataPoint>();
    
                S1.Add(new DataPoint(4, 10));
                S1.Add(new DataPoint(6, 20));
                S1.Add(new DataPoint(8, 15));
                S1.Add(new DataPoint(9, 70));
                S1.Add(new DataPoint(10, 5));
    
                S2.Add(new DataPoint(1, 0));
                S2.Add(new DataPoint(2, 0));
                S2.Add(new DataPoint(3, 0));
                S2.Add(new DataPoint(6, 0));
                S2.Add(new DataPoint(7, 0));
                S2.Add(new DataPoint(8.1, 0));
                S2.Add(new DataPoint(8.2, 0));
                S2.Add(new DataPoint(8.3, 0));
                S2.Add(new DataPoint(8.4, 0));
                S2.Add(new DataPoint(9, 0));
                S2.Add(new DataPoint(9.75, 0));
                S2.Add(new DataPoint(11, 0));
                S2.Add(new DataPoint(12, 0));
                S2.Add(new DataPoint(16, 0));
    
               NS1 = GetMiddlePoints(S1, S2);
               foreach (DataPoint pointin NS1)
               {
                   MessageBox.Show( point.X.ToString()+" : "+ point.Y.ToString());
               }
    
    
            }
    
            #region GetMiddlePoints
            private List<DataPoint> GetMiddlePoints(List<DataPoint> S1, List<DataPoint> S2)
            {
                List<DataPoint> NS1 = new List<DataPoint>();
    
                int i = 0;
                int j = S2.TakeWhile(p => p.X < S1[0].X).Count();
                
    
                int PointsInS1 = S1.Count;
                int PointsInS2 = S2.Count;
    
                DataPoint newPoint = new DataPoint();
                
    
                while (i < PointsInS1 )
                {
                    if (j < PointsInS2 )
                    {
                        if (S1[i].X < S2[j].X)
                        {
                            newPoint = S1[i];
                            NS1.Add(newPoint );
                            i++;
                        }
    
                        else if (S1[i].X == S2[j].X)
                        {
                            newPoint = S1[i];
                            NS1.Add(newPoint );
                            i++;
                            j++;
                        }
    
                        else if (S1[i].X > S2[j].X)
                        {
                            newPoint .X = S2[j].X;
                            newPoint .Y = S1[i-1].Y + (S2[j].X - S1[i-1].X) * (S1[i].Y - S1[i-1].Y) / (S1[i].X - S1[i-1].X);
                            NS1.Add(newPoint );
                            j++;
                            
                        }
                        
                    }
    
                    if (j == PointsInS2 )
                    {
                        newPoint = S1[i];
                        NS1.Add(newPoint );
                        i++;
                    }
    
    
                }
    
    
                return NS1;
    
            }
    
            #endregion
    
        }
    }
