        EllipseGeometry hitArea = new EllipseGeometry(e.GetPosition(this), 5, 5);
        VisualTreeHelper.HitTest(MainGrid, null, new HitTestResultCallback(ToolTipCallback), new GeometryHitTestParameters(hitArea));//MainGrid would be your ListBox
    }
    private HitTestResultBehavior ToolTipCallback(HitTestResult hitTestResult)
    {
        GeometryHitTestResult geometryHitTestResult = ((GeometryHitTestResult)hitTestResult);
        if (geometryHitTestResult.VisualHit.GetType() == typeof(Rectangle))
        {
            Path potentialToolTip = (Path)geometryHitTestResult.VisualHit;
            if (potentialToolTip.Tag.ToString().Contains("CustomToolTip"))
            {
                //Show Custom ToolTip
                return HitTestResultBehavior.Stop;
            }
        }
        return HitTestResultBehavior.Stop;
    }
