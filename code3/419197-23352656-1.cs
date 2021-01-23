    StrokeCollection sc = InkCanvas1.GetSelectedStrokes();
    Rect r = sc.GetBounds();
   
    PointCollection pc = new PointCollection();
    //Shift all the points by the calculated extent of the strokes.
    Matrix mat = new Matrix();
    mat.Translate(-r.Left, -r.Top);
    sc.Transform(mat, false);
    foreach (Stroke s in sc)
    {
        foreach (Point p in s.StylusPoints){pc.Add(p);}
    }
    Polygon poly_ = new Polygon();
    
    //Shift the polygon back to original location
    poly_.SetValue(InkCanvas.LeftProperty, r.Left);
    poly_.SetValue(InkCanvas.TopProperty, r.Top);
    poly_.Points = pc;
    InkCanvas1.Children.Add(poly_);
