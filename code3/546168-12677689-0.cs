     protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
            }
            else
            {
                base.OnMouseDown(e);
            }
        }     
