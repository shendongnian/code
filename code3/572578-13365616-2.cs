    class CutomToolStripMenuRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
                base.OnRenderMenuItemBackground(e);
        }
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
                base.OnRenderMenuItemBackground(e);
        }
    }
2. set this renderer to your menu strip:
    menuStrip1.Renderer = new CustomToolStripRenderer();
hope this helps.
  [1]: http://msdn.microsoft.com/en-us/library/ms229634.aspx
