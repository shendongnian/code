        // Get scale transformation (find scale factor)
        var w = (gem2_Copy.ActualWidth / gem2_Copy.Data.Bounds.Width);
        var h = (gem2_Copy.ActualHeight / gem2_Copy.Data.Bounds.Height);
        var transform = new ScaleTransform(w, h);
            
        foreach (var figure in geom.Figures)
        {
          foreach (LineSegment segment in figure.Segments)
          {
            // Use scale transformation to change geometry points position.
            var scaled=transform.Transform(segment.Point);
            					
            // Translate point to screen coordinates (including rotation)
            var onScreen = canvas.TranslatePoint(scaled, root);
            
            // Use line intersection formula
          }
        }
