     private void Form1_Load(object sender, EventArgs e)
        {
            // Create an instance of Graph Pane
            GraphPane myPane = zedGraphControl1.GraphPane;
            // Build a PointPairList with points based on Sine wave
            PointPairList list = new PointPairList();
            for (double i = 0; i < 36; i++)
            {
                double x = i * 10.0 + 50.0;
                double y = Math.Sin(i * Math.PI / 15.0) * 16.0;
                list.Add(x, y);
            }
            // Hide the legend
            myPane.Legend.IsVisible = false;
            // Add a curve
            LineItem curve = myPane.AddCurve("label", list, Color.Red, SymbolType.Circle);
            curve.Line.Width = 1.5F;
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 5;
            // Make the XAxis start with the first label at 50
            myPane.XAxis.Scale.BaseTic = 50;
            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.SteelBlue, 45.0F); 
            // Draw Region 1
            drawRegion(list[0].X, list[10].X,"Positive Cycle");
            
            // Calculate the Axis Scale Ranges
            zedGraphControl1.AxisChange();
            // Refresh to paint the graph components
            Refresh(); 
        }
        private void drawRegion(double xMin, double xMax, string regName)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            BoxObj box = new BoxObj(xMin,20, xMax, 40.0, Color.Empty, Color.LightSteelBlue);// Color.FromArgb(225, 245, 225));
            box.Location.CoordinateFrame = CoordType.AxisXYScale;
            box.Location.AlignH = AlignH.Left;
            box.Location.AlignV = AlignV.Top;
            
            // place the box behind the axis items, so the grid is drawn on top of it
            box.ZOrder = ZOrder.E_BehindCurves;//.D_BehindAxis;//.E_BehindAxis;
            pane.GraphObjList.Add(box);
            // Add Region text inside the box 
            TextObj myText = new TextObj(regName, 160, -15);
            myText.Location.CoordinateFrame = CoordType.AxisXYScale;
            myText.Location.AlignH = AlignH.Right;
            myText.Location.AlignV = AlignV.Center;
            myText.FontSpec.IsItalic = true;
            myText.FontSpec.IsBold = false;
            myText.FontSpec.FontColor = Color.Red;
            myText.FontSpec.Fill.IsVisible = false;
            myText.FontSpec.Border.IsVisible = false;
            pane.GraphObjList.Add(myText);
            zedGraphControl1.Refresh();
        }
