     Steema.TeeChart.Tools.CursorTool cursorTool1;
     private Steema.TeeChart.Tools.Annotation ann;
     private double xval;
     private void InitializeChart()
     {
         tChart1.Aspect.View3D = false;
         //Tools
         cursorTool1 = new Steema.TeeChart.Tools.CursorTool(tChart1.Chart);
         cursorTool1.Style = Steema.TeeChart.Tools.CursorToolStyles.Vertical;
        // cursorTool1.Pen.Style = System.Drawing.Drawing2D.DashStyle.Dash;
         cursorTool1.FollowMouse = true;
     
       //  cursorTool1.OriginalCursor = Cursors.Arrow;
         ann = new Steema.TeeChart.Tools.Annotation(tChart1.Chart);
         ann.Shape.Pen.Visible = false;
         ann.Shape.Shadow.Visible = false;
         ann.Shape.ShapeStyle = Steema.TeeChart.Drawing.TextShapeStyle.RoundRectangle;
         //Series
         Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line(tChart1.Chart);
         line1.XValues.DateTime = true;
         line1.DateTimeFormat = "HH:mm:ss";
         cursorTool1.Series = line1;
         line1.Stairs = true;
         line1.XValues.DataMember = "SetTime";
         line1.YValues.DataMember = "Park Brk Pres Sw1";
         line1.DataSource = GetDataTable();
       
        tChart1.Axes.Bottom.Labels.DateTimeFormat = "HH:mm:ss";
        tChart1.Axes.Bottom.Labels.Style = Steema.TeeChart.AxisLabelStyle.PointValue;
        tChart1.Export.Data.Excel.Save("C:\\Test1.xls");
        //Events
        tChart1.AfterDraw += new PaintChartEventHandler(tChart1_AfterDraw);
        cursorTool1.Change += new CursorChangeEventHandler(cursorTool1_Change);
        tChart1.Draw();
     }
    //DataTable
     private DataTable GetDataTable()
     {
         DataTable dataTable1 = new DataTable("DataSet");
         //Condition to filter
         //AddColumns in new Table
         DataColumn xval = new DataColumn("SetTime", typeof(DateTime));
         DataColumn yval = new DataColumn("Park Brk Pres Sw1", typeof(double));
         dataTable1.Columns.Add(xval);
         dataTable1.Columns.Add(yval);
         DateTime dt = DateTime.Now;
         for (int i = 0; i < 10; i++)
         {
             DataRow newRow = dataTable1.NewRow();
             newRow[xval] = dt.AddSeconds(i * 5);
             newRow[yval] = 0;
             dataTable1.Rows.Add(newRow);
         }
         return dataTable1;
     }
    //Calculate Interpolate point
     private double InterpolateLineSeries(Steema.TeeChart.Styles.Custom series, int firstindex, int lastindex, double xvalue)
     {
         int index;
         for (index = firstindex; index <= lastindex; index++)
         {
             if (index == -1 || series.XValues.Value[index] > xvalue) break;
         }
         // safeguard
         if (index < 1) index = 1;
         else if (index >= series.Count) index = series.Count - 1;
         // y=(y2-y1)/(x2-x1)*(x-x1)+y1
         double dx = series.XValues[index] - series.XValues[index - 1];
         double dy = series.YValues[index] - series.YValues[index - 1];
         if (dx != 0.0) return dy * (xvalue - series.XValues[index - 1]) / dx + series.YValues[index - 1];
         else return 0.0;
     }
     private double InterpolateLineSeries(Steema.TeeChart.Styles.Custom series, double xvalue)
     {
         return InterpolateLineSeries(series, series.FirstVisibleIndex, series.LastVisibleIndex, xvalue);
     }
     private void cursorTool1_Change(object sender, Steema.TeeChart.Tools.CursorChangeEventArgs e)
     {
         xval = e.XValue;
         ann.Text = "";
    
        this.Text = e.ValueIndex.ToString();
        foreach (Steema.TeeChart.Styles.Series s in tChart1.Series)
        {
            ann.Text += DateTime.FromOADate(s.XValues[e.ValueIndex]).ToString("HH:mm:ss");
        }
     }
     private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
     {
         int xs = tChart1.Axes.Bottom.CalcXPosValue(xval);
         int ys;
         g.Brush.Visible = true;
         g.Brush.Solid = true;
         for (int i = 0; i < tChart1.Series.Count; i++)
             if (tChart1.Series[i] is Steema.TeeChart.Styles.Custom)
             {
                 ys = tChart1.Series[i].GetVertAxis.CalcYPosValue(InterpolateLineSeries(tChart1.Series[i] as Steema.TeeChart.Styles.Custom, xval));
                 //Draw elipse above cursor tool.
                 g.Brush.Color = tChart1.Series[i].Color;
                 //Draw annotation as label above cursor tool.
                 ann.Top = ys;
                 ann.Left = xs;
             }
     }
