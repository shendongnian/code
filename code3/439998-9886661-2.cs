    public class RenderOrderComparer : IComparer<IRenderable>
    {
        public int Compare(IRenderable a, IRenderable b)
        {
           if (a.IsOverlay && !b.IsOverlay)
             return -1;
           if (b.IsOverlay && !a.IsOverlay)
             return 1,
           if (a.IsTransparent && !b.IsTransparent)
             return -1;
           if (b.IsTransparent && !a.IsTransparent)
             return 1;
           // ...and so on.
    
           return 0;
        } 
    }
