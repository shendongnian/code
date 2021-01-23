    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {       
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {                                    
            if (RenderArrow != null) RenderArrow(this, e);
            base.OnRenderArrow(e);            
        }
        public new event ToolStripArrowRenderEventHandler RenderArrow;//This will hide the default RenderArrow event which can't help you change the e argument because the default is fired after the Arrow is rendered.
    }
    //Now you have to create your own List<ToolStripItem> to contain all the items whose arrows should not be rendered
    List<ToolStripItem> ItemsWithoutArrow = new List<ToolStripItem>();
    //Add a method to add an item to that list
    private void SuppressDrawArrow(ToolStripItem item)
    {
       if (!ItemsWithoutArrow.Contains(item)) ItemsWithoutArrow.Add(item);
    }
    //Assign custom ToolStripRenderer for your MenuStrip
    menuStrip1.Renderer = new CustomToolStripRenderer();
    //Now add a RenderArrow event handler, this RenderArrow event is the new we created in the class CustomToolStripRenderer
    ((CustomToolStripRenderer)menuStrip1.Renderer).RenderArrow += (s, e) =>
     {                
        if(ItemsWithoutArrow.Contains(e.Item)) e.ArrowRectangle = Rectangle.Empty;
     };
    //Add some item to the ItemsWithoutArrow to test
    SuppressDrawArrow(item1ToolStripMenuItem);
