    public HitTestResultBehavior leftClickCallback(HitTestResult result)
    {
        var visual = result.VisualHit as DrawingVisual;
        if (visual != null)
        {
            var element = visual.Parent as MyCustomElement;
            if (element != null)
            {
                if (element.Opacity == 1.0)
                {
                    element.Opacity = 0.4;
                }
                else
                {
                    element.Opacity = 1.0;
                }
            }
        }
        return HitTestResultBehavior.Stop;
    }
