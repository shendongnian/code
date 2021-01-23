	// Get system DPI
	Matrix m = PresentationSource.FromVisual(Application.Current.MainWindow).CompositionTarget.TransformToDevice;
	if (m.M11 > 0 && m.M22 > 0)
	{
		dpiXFactor = m.M11;
		dpiYFactor = m.M22;
	}
	else
	{
		// Sometimes this can return a matrix with 0s. Fall back to assuming normal DPI in this case.
		dpiXFactor = 1;
		dpiYFactor = 1;
	}
