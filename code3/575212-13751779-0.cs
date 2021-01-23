         foreach (System.Web.UI.DataVisualization.Charting.Series serien in Chart1.Series)
         {
                    foreach(System.Web.UI.DataVisualization.Charting.DataPoint dataPoint in serien.Points)
                    {
                        if (dataPoint.YValues[0] == 0)
                        { 
                           dataPoint.IsEmpty = true;
                        }
                    }
                    serien.Sort(PointSortOrder.Ascending,sortBy:("X"));
         }
