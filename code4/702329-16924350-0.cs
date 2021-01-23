    BoxObj box = new BoxObj(3, 70, 1, 70, Color.Empty,Color.FromArgb(100, Color.LightGreen));
    box.Fill = new Fill(Color.White, Color.FromArgb(120, Color.LightGreen), 45.0F);
    box.ZOrder = ZOrder.A_InFront;
    box.IsClippedToChartRect = true;
    box.Location.CoordinateFrame = CoordType.AxisXYScale;
