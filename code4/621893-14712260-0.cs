    // Although the visual template we're applying is a circle,
    // the FUNCTIONALITY is primarily that of a thumb. So that's what 
    // we'll use. A thumb is essentially a 'draggable thing'.
    class DragCircle : System.Windows.Controls.Primitives.Thumb
    {      
        public DragCircle()
        {
            // Thumbs _track_ movement, but they don't actually move. We have to handle this ourselves.
            // We do this by setting the Canvas.Left/Canvas.Top attached properties. Of course, for this
            // to work our DragCircle has to be placed on a Canvas, otherwise there's no-one to read the property.
            // IMPORTANT! In order to read the Canvas position later, it needs to have a record in the WPF 
            // dependency property table. So for now we'll just set it to '0' as a default.
            Canvas.SetLeft (this, 0);
            Canvas.SetTop (this, 0);
            
            // The drag-delta event occurs when the Thumb is dragged. 'delta' represents "change" just like
            // we all learned in calculus.
            this.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(DragCircle_DragDelta);
        }
        void DragCircle_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            // Read the Canvas location from the WPF database.
            Double currentX = Canvas.GetLeft(this);
            Double currentY = Canvas.GetTop(this);
            // Now update the canvas attached properties using the drag-delta ('change in position').
            // Note that Canvas.SetLeft is just a helper function that maps to the attached property: 
            //  this.SetValue(Canvas.TopProperty, SOME_VALUE);
            Canvas.SetLeft(this, currentX + e.HorizontalChange);
            Canvas.SetTop(this, currentY + e.VerticalChange);
        }
    }
