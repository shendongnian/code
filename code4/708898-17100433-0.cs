    private class BackgroundImageRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
            }
            else
            {
                if (e.Item.Name == "theNameOfMyToolStripMenuItem")
                {
                    Image backgroundImage = global::YourProject.Properties.Resources.ImageFileName;
                    e.Graphics.DrawImage(backgroundImage, 0, 0, e.Item.Width, e.Item.Height);
                }
                else {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }
    }
