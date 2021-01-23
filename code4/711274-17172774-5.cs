    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {       
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {                                    
           if(!itemsWithoutArrow.Contains(e.Item)) base.OnRenderArrow(e);            
        }
        public void SuppressDrawArrow(ToolStripItem item){
           if (!itemsWithoutArrow.Contains(item)) itemsWithoutArrow.Add(item);
        }
        public void AllowDrawArrow(ToolStripItem item){
           itemsWithoutArrow.Remove(item);
        }
        private List<ToolStripItem> itemsWithoutArrow = new List<ToolStripItem>();
    }
    //Use in code
    CustomToolStripRenderer renderer = new CustomToolStripRenderer();
    renderer.SuppressDrawArrow(item1ToolStripMenuItem);
    menuStrip1.Renderer = renderer;    
    //This solution fits your requirement (draw or don't draw arrow) but if you also want to change such as ArrowColor, the previous solution would be better.
