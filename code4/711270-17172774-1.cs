    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {       
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {            
            e.ArrowRectangle = Rectangle.Empty;//Don't draw arrow
            base.OnRenderArrow(e);
        }
    }
    //and update the Renderer property of your MenuStrip
    menuStrip1.Renderer = new CustomToolStripRenderer();
