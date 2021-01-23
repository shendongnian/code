    public class AreaDrawingEdit : FrameworkElement
    {
        public VisualCollection Visuals { get; set; }
        const double COLLISION_OPACITY = 0.8;
     
        public AreaDrawingEdit()
        {
            Visuals = new VisualCollection(this);
        }
        public void AddRenderTile(DrawingTile tile)
        {
            // Add the tile visual 
            tile.visual = new DrawingVisual();
            InvalidateTile(tile);
            Visuals.Add(tile.visual);
            // Add in collision visual
            tile.colVol.visual = new DrawingVisual();
            InvalidateCollisionVol(tile.colVol);
            Visuals.Add(tile.colVol.visual);
        }
        public void RemoveRenderTile(DrawingTile tile)
        {
            Visuals.Remove(tile.visual);
            Visuals.Remove(tile.colVol.visual);
        }
        public void InvalidateTile(DrawingTile tile)
        {
            // Set up drawing rect for new tile
            Rect r = new Rect(tile.pos, new Size(tile.tileTex.src.PixelWidth, tile.tileTex.src.PixelHeight));
            DrawingContext dc = tile.visual.RenderOpen();
            dc.DrawImage(tile.tileTex.src, r);
            dc.Close();
        }
        public void InvalidateCollisionVol(CollisionVol vol)
        {
            Rect r = new Rect(vol.pos, vol.size);
            
            DrawingContext dc = vol.visual.RenderOpen();
            dc.PushOpacity(COLLISION_OPACITY);
            dc.DrawImage(vol.src, r);
            dc.Pop();
            dc.Close();
        }
        protected override int VisualChildrenCount
        {
            get { return Visuals.Count; }
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= Visuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Visuals[index];
        }
    }
