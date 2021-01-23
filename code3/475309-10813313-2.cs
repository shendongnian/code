    toolStrip.Renderer = new PressedRenderer();
    //...    
    
    class PressedRenderer : ToolStripProfessionalRenderer {
        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e) {
            if(e.Item.Pressed)
                e.Graphics.Clear(Color.Green);
            else base.OnRenderDropDownButtonBackground(e);
        }
    }
