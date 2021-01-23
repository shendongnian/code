        // Create the rectangle with the moving element width and height
        Size draggedElementSize = new Size(this.DraggedElement.ActualWidth, this.DraggedElement.ActualHeight);
        Rect draggedElementRect = new Rect(draggedElementSize);
        draggedElementRect.offset(VisualTreeHelper.GetOffset(this.DraggedElement));
        foreach (Canvas c in canvases)
        {
            if (this.DraggedElement == c) continue; // skip dragged element.
            // Create a rectangle for each canvas
            Size s = new Size(c.ActualWidth, c.ActualHeight);
            Rect r = new Rect(s);
            r.offset(VisualTreeHelper.GetOffset(c));
            // Get the intersected area
            Rect currentIntersection = Rect.Intersect(r, draggedElementRect);
            if (currentIntersection == Rect.Empty) // this is never true
                return;
        } // end-foreach
