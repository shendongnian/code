    public class GraphicsPalette : IDisposable 
    {
        [ThreadStatic]
        private static GraphicsPalette _current = null;
        private readonly Dictionary<Color, SolidBrush> _solidBrushes = new Dictionary<Color, SolidBrush>();
    
        public GraphicsPalette() 
        {
            if (_current == null)
                _current = this;
        }
        
        public void Dispose() 
        {
            if (_current == this)
                _current = null;
    
            foreach (var solidBrush in _solidBrushes.Values)
                solidBrush.Dispose();            
        }
    
        public static SolidBrush GetSolidBrush(Color color) 
        {
            if (!_current._solidBrushes.ContainsKey(color))
                _current._solidBrushes[color] = new SolidBrush(color);
    
            return _current._solidBrushes[color];
        }
    }
