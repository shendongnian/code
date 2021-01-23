    public class MyUserControl : UserControl
    {
        bool dragging = false;
    
        // ...
    
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (dragging)
            {
                // We've finished dragging, don't call MouseClick
                dragging = false;
                return;
            }
    
            // Not dragging, fire MouseClick
            base.OnMouseClick(e);
        }
    }
