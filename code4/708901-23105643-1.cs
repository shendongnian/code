    public class customRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            // check if the object being rendered is actually a ToolStripButton
            if (e.Item is ToolStripButton)
            {
                ToolStripButton button = e.Item as ToolStripButton;
                // only render checked items differently
                if (button.Checked || button.Selected)
                {
                   //do work here
                }
                else
                    base.OnRenderButtonBackground(e);
            }
            // if this object is not a ToolStripButton, use the normal render event
            else
                base.OnRenderButtonBackground(e);
        }
        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            //do checking here like above
            base.OnRenderItemBackground(e);
        }
    }
