        ModelVisual3D GetHitResult(Point location)
        {
        HitTestResult result = VisualTreeHelper.HitTest(mainViewport, location);
        if(result != null && result.VisualHit is ModelVisual3D)
        {
		ModelVisual3D visual = (ModelVisual3D)result.VisualHit;
		return visual;
        }
        return null;
        }
