            myZg = new ZedGraphControl();
            GraphPane myPane = myZg.GraphPane;
            // Init lists
            RadarPointList dseries1 = new RadarPointList();
            RadarPointList dseries2 = new RadarPointList();
            // Maximize available space in pane
            myPane.Legend.Position = LegendPos.InsideTopLeft;
            myPane.Title.IsVisible = false;
            myPane.XAxis.IsVisible = false;
            myPane.YAxis.IsVisible = false;
            myPane.Border.IsVisible = false;
            myPane.Chart.Border.IsVisible = false;
            myPane.Margin.All = 0;
            // Create concentric grid with 30 degrees spacing & add corresponding labels
            for (double i = 0; i < 36; i+=3.0)
            {
                TextObj gridlbs = new TextObj((i * 10.0).ToString("0°"), (radius + 10.0) * Math.Cos((i * 10.0 * Math.PI) / 180.0), (radius + 10.0) * Math.Sin((i * 10.0 * Math.PI) / 180.0));
                gridlbs.FontSpec.Border.IsVisible = false;
                LineObj gridlns = new LineObj(0, 0, radius * Math.Cos((i * 10.0 * Math.PI) / 180.0), radius * Math.Sin((i * 10.0 * Math.PI) / 180.0));
                myPane.GraphObjList.Add(gridlbs);
                myPane.GraphObjList.Add(gridlns);
            }
            // Draw circular grid, 5 should look okay
            for (double i = (radius / 5.0); i <= radius; i += (radius / 5.0))
            {
                EllipseObj gridcrl = new EllipseObj(-i, i, 2.0 * i, 2.0 * i);
                gridcrl.ZOrder = ZOrder.E_BehindCurves;
                myPane.GraphObjList.Add(gridcrl);
            }
            // Make sure the pane is big enough to fit the labels around the polar plot
            myPane.XAxis.Scale.Min = -(radius + 20.0);
            myPane.XAxis.Scale.Max = (radius + 20.0);
            myPane.YAxis.Scale.Min = -(radius + 20.0);
            myPane.YAxis.Scale.Max = (radius + 20.0);
            _selectedRadius = radius;
            // Keep X & Y axis in the correct ratio to avoid distorting polar circle 
            myZg_Resize((object)"Startup", EventArgs.Empty);
            myZg.Resize += new EventHandler(myZg_Resize);
            myZg.ZoomEvent  += new ZedGraphControl.ZoomEventHandler(myZg_ZoomEvent2);
            // Draw snailly curves (example)
            for (int i = 0; i < 360; i++)
            {
                double r = (double)i/360.0 * radius;
                PointPair pt = new PointPair(PointPair.Missing, r, null);
                dseries1.Add(pt);
                PointPair pt2 = new PointPair(PointPair.Missing, radius - r, null);
                dseries2.Add(pt2);
            }
            // Curves are somple LineItem
            FirstCurve = myPane.AddCurve("Snail", dseries1, Color.Blue, SymbolType.None);
            SecondCurve = myPane.AddCurve("antiSnail", dseries2, Color.Red, SymbolType.None);
            // Rotate the lists to aling with labels
            dseries1.Rotation = 0;
            dseries2.Rotation = 0;
