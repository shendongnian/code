        int nSeries = 3;
        private void InitializeChart()
        {
            tChart1.Aspect.View3D = false;
            tChart1.Header.Visible = false;
            tChart1.Legend.Alignment = LegendAlignments.Bottom;
            for (int i = 0; i < nSeries; i++)
            {
                new Steema.TeeChart.Styles.Line(tChart1.Chart);
                tChart1.Axes.Custom.Add(new Steema.TeeChart.Axis(tChart1.Chart));
                tChart1[i].CustomVertAxis = tChart1.Axes.Custom[i];
                tChart1.Axes.Custom[i].AxisPen.Color = tChart1[i].Color;
                tChart1.Axes.Custom[i].Grid.Visible = false;
                tChart1.Axes.Custom[i].Title.Visible = true;
                tChart1.Axes.Custom[i].Title.Caption = "Series" + i.ToString();
                tChart1[i].FillSampleValues(20);
                tChart1.Axes.Custom[i].PositionUnits = PositionUnits.Pixels;
            }
            tChart1.Panel.MarginUnits = PanelMarginUnits.Pixels;
            tChart1.Draw();
            PlaceAxes(0, 0, 0, 0, 0);
            tChart1.Draw();
        }
        private void PlaceAxes(int nSeries, int NextXLeft, int NextXRight, int MargLeft, int MargRight)
        {
            const int extraPos = 12;
            const int extraMargin = 105;
            //Variable
            int MaxLabelsWidth;
            int lenghtTicks;
            int extraSpaceBetweenTitleAndLabels;
            if (tChart1[nSeries].Active)
            {
                MaxLabelsWidth = tChart1.Axes.Custom[nSeries].MaxLabelsWidth();
                lenghtTicks = tChart1.Axes.Custom[nSeries].Ticks.Length;
                extraSpaceBetweenTitleAndLabels = (tChart1.Axes.Custom[nSeries].Title.Width);//- tChart1.Axes.Custom[nSeries].MaxLabelsWidth());
                if (tChart1.Axes.Custom[nSeries].OtherSide)
                {
                    tChart1.Axes.Custom[nSeries].RelativePosition = NextXRight;
                    NextXRight = NextXRight - (MaxLabelsWidth + lenghtTicks + extraSpaceBetweenTitleAndLabels + extraPos);
                    MargRight = MargRight + extraMargin;
                }
                else
                {
                    tChart1.Axes.Custom[nSeries].RelativePosition = NextXLeft;
                    NextXLeft = NextXLeft - (MaxLabelsWidth + lenghtTicks + extraSpaceBetweenTitleAndLabels + extraPos);
                    MargLeft = MargLeft + extraMargin;
                }
                tChart1.Panel.MarginLeft = MargLeft;
                tChart1.Panel.MarginRight = MargRight;
                nSeries++;
                if (nSeries <= tChart1.Series.Count - 1)
                {
                    PlaceAxes(nSeries, NextXLeft, NextXRight, MargLeft, MargRight);
                }
            }
        }
