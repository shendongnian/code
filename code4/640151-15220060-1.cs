    public Form1()
            {
                InitializeComponent();
                InitializeChart();
            }
    
            private DataSet GetData()
            {
                DataSet TeeDataSet = new DataSet();
                DateTime dt = DateTime.Today;
                DataTable TeeDataTable = new DataTable("DataTable1");
                DataColumn xval = new DataColumn("DateTime", typeof(DateTime));
                DataColumn yval = new DataColumn("SystemName", typeof(double));
    
                TeeDataTable.Columns.Add(xval);
                TeeDataTable.Columns.Add(yval);
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    DataRow newRow = TeeDataTable.NewRow();
                    newRow[xval] = dt;
                    newRow[yval] = rnd.Next(100);
                    TeeDataTable.Rows.Add(newRow);
                    dt = dt.AddMonths(1);
                }
                TeeDataSet.Tables.Add(TeeDataTable);
                return TeeDataSet;
            }
            private void InitializeChart()
            {
                tChart1.Aspect.View3D = false;
                tChart1.Header.Visible = false;
                tChart1.Legend.Alignment = LegendAlignments.Bottom;
                tChart1.Legend.CheckBoxes = true;
                for (int i = 0; i < 5; i++)
                {
                    new Steema.TeeChart.Styles.Line(tChart1.Chart);
                    tChart1[i].Title = "SystemName";
                    tChart1[i].DataSource = GetData();//Add values using DataSource
                    tChart1[i].XValues.DataMember = "DateTime";
                    tChart1[i].XValues.DateTime = true;
                    tChart1[i].XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
                    tChart1[i].YValues.DataMember = "SystemName";
                    tChart1.Axes.Custom.Add(new Steema.TeeChart.Axis(tChart1.Chart));
                    tChart1[i].CustomVertAxis = tChart1.Axes.Custom[i];
                    tChart1.Axes.Custom[i].AxisPen.Color = tChart1[i].Color;
                    tChart1.Axes.Custom[i].Grid.Visible = false;
      
                    tChart1.Axes.Custom[i].PositionUnits = PositionUnits.Pixels;
                }
    
                tChart1.Panel.MarginUnits = PanelMarginUnits.Pixels;
                tChart1.Panel.MarginTop = 20;
                tChart1.Draw();
                PlaceAxes(0, 0, 0, 0, 0);
                tChart1.AfterDraw += new PaintChartEventHandler(tChart1_AfterDraw);
                tChart1.ClickLegend += new MouseEventHandler(tChart1_ClickLegend);
                tChart1.Draw();
            }
    
            void tChart1_ClickLegend(object sender, MouseEventArgs e)
            {
                tChart1.Draw();
            }
    
            void tChart1_AfterDraw(object sender, Graphics3D g)
            {
                PlaceAxes(0, 0, 0, 0, 0);
            }
    
            private void PlaceAxes(int nSeries, int NextXLeft, int NextXRight, int MargLeft, int MargRight)
            {
                const int extraPos = 12;
                const int extraMargin = 60;
                //Variable 
                int MaxLabelsWidth;
                int lenghtTicks;
                int extraSpaceBetweenTitleAndLabels;
                foreach (Steema.TeeChart.Styles.Line s in tChart1.Series)
                {
                    if (s.Active)
                    {
                        s.CustomVertAxis.Visible = true;
                        s.CustomVertAxis.SetMinMax(tChart1[0].YValues.Minimum, tChart1[0].YValues.Maximum);
                        MaxLabelsWidth = s.CustomVertAxis.MaxLabelsWidth();
                        lenghtTicks = s.CustomVertAxis.Ticks.Length;
                        extraSpaceBetweenTitleAndLabels = (s.CustomVertAxis.Title.Width);//- tChart1.Axes.Custom[nSeries].MaxLabelsWidth());
                        if (s.CustomVertAxis.Title.Visible)
                        {
                            s.CustomVertAxis.RelativePosition = NextXLeft;
                            NextXLeft = NextXLeft - (MaxLabelsWidth + lenghtTicks + extraSpaceBetweenTitleAndLabels + extraPos);
                            MargLeft = MargLeft + extraMargin;
                        }
    
                        else
                        {
                            s.CustomVertAxis.RelativePosition = NextXLeft;
                            NextXLeft = NextXLeft - (MaxLabelsWidth + lenghtTicks + extraPos);
                            MargLeft = MargLeft + extraMargin;
                        }
    
                        tChart1.Panel.MarginLeft = MargLeft;
                        tChart1.Panel.MarginRight = MargRight;
    
                    }
                    else
                    {
                        s.CustomVertAxis.Visible = false;
                    }
                }
            }
         
