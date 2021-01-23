        class BitmapCanvas : ICanvas
        {
            private readonly byte[] _bitmapData;
            private readonly List<IBitmapShape> _primitives;
            public BitmapCanvas(int width, int height)
            {
                _bitmapData = new byte[width * height];
                _primitives = new List<IPrimitiveShape>();
            }
            public void DrawLine(...) 
            {
                // different implementations will handle this part differently.
                _primitives.Add(new BitmapLine(_bitmapData, from, to, pen));
            }
    
            public void Paint()
            {
                Clear(_bitmapData);
                foreach (var shape in _primitives)
                    shape.Draw();
            }
        }
