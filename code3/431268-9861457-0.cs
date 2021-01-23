    public class CellRendererAlignedText : CellRendererText
	{
		/**
		 * Overridden render method to position text correctly.
		 * */
		protected override void Render (Gdk.Drawable window, 
		                                Widget widget, 
		                                Gdk.Rectangle background_area, 
		                                Gdk.Rectangle cell_area, 
		                                Gdk.Rectangle expose_area, 
		                                CellRendererState flags)
		{
			if (Alignment == Pango.Alignment.Center)
			{	
				cell_area.X += background_area.Width/4;
				cell_area.Width /= 2;
			}
			base.Render (window, widget, background_area, cell_area, expose_area, flags);
		}
    }
