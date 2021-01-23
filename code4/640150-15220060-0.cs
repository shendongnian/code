     public Form1()
            {
                InitializeComponent();
                InitializeChart();
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
                    tChart1.Axes.Custom.Add(new Steema.TeeChart.Axis(tChart1.Chart));
                    tChart1[i].CustomVertAxis = tChart1.Axes.Custom[i];
                    tChart1.Axes.Custom[i].AxisPen.Color = tChart1[i].Color;
                    tChart1.Axes.Custom[i].Grid.Visible = false;
                                  
                    tChart1[i].FillSampleValues(20);
                    tChart1.Axes.Custom[i].PositionUnits = PositionUnits.Pixels;
                    tChart1.Axes.Custom[i].SetMinMax(0, 1500);
                    tChart1.Axes.Custom[i].Increment = 100;
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
     
