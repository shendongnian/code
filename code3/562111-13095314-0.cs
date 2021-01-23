        public class MyPanel : Panel
        {
            protected override void OnControlAdded(ControlEventArgs e)
            {
                e.Control.MouseLeave += DidMouseReallyLeave; 
                base.OnControlAdded(e);
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                DidMouseReallyLeave(this, e);
            }
            private void DidMouseReallyLeave(object sender, EventArgs e)
            {
                if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                    return;
                base.OnMouseLeave(e);
            }
        }
