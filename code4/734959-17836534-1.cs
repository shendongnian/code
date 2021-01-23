    dtSr.Load(reader);
            if(dtSr.Columns==null)
            {
                for (int i = 0; i < seriesa.Length; i++)
                {
                    Chart3.Series[seriesa[i]].Points.AddY(0);
                }
            }
            else
            {
                Chart3.DataSource = dtSr;                                                    
                Chart3.Series["s2"].YValueMembers = "YTD";
                Chart3.Series["s3"].YValueMembers = "soll";
                Chart3.Series["s1"].YValueMembers = "KW_Mittel";
                Chart3.DataManipulator.InsertEmptyPoints(1, System.Web.UI.DataVisualization.Charting.IntervalType.Number, Chart3.Series["s3"]);
                Chart3.DataManipulator.InsertEmptyPoints(1, System.Web.UI.DataVisualization.Charting.IntervalType.Number, Chart3.Series["s2"]);
                Chart3.Series["s3"].EmptyPointStyle.Color = System.Drawing.Color.Transparent;
                Chart3.Series["s2"].EmptyPointStyle.Color = System.Drawing.Color.DarkGreen;
                Chart3.Series["s2"].BorderWidth = 2;
                Chart3.DataBind();
            }           
