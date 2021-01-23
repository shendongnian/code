    class Generator
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Radius { get; private set; }
    
        private List<int> _numbers;
        private bool[] _picked;
        private int[] _grid;
        private Random _rnd;
    
        public Generator(int width, int height, int radius)
        {
            Width = width;
            Height = height;
            Radius = radius;
    
            _rnd = new Random();
            _numbers = Enumerable.Range(0,Width*Height).OrderBy(_ => _rnd.Next()).ToList();
            _picked = _numbers.Select(n => false).ToArray();
            _grid = new int[width*height];
        }
    
        public int[] Generate()
        {
            return Generate(0)
                .Select(a => a.ToArray()) // copy
                .FirstOrDefault();
        }
    
        private IEnumerable<int[]> Generate(int index)
        {
            if (index >= Width * Height)
            {
                yield return _grid;
                yield break;
            }
    
            int xmid = index%Width;
            int xlow = Math.Max(0, xmid - Radius);
            int xhigh = Math.Min(xmid + Radius, Width - 1);
            int ymid = index/Width;
            int ylow = Math.Max(0, ymid - Radius);
            int yhigh = ymid;
            
            var validNumbers = _numbers
                .Where(n =>
                    !_picked[n] &&
                    Enumerable.Range(xlow, xhigh - xlow + 1).All(x =>
                        Enumerable.Range(ylow, yhigh-ylow+1).All(y =>
                            y*Width + x >= index // Not generated yet
                            || Math.Abs(x - xmid) + Math.Abs(y - ymid) > Radius // Outside radius
                            || Math.Abs(_grid[y*Width+x] - n) > 1 // Out of range
                        )
                    )
                )
                .ToList();
    
            foreach (var n in validNumbers)
            {
                _grid[index] = n;
                _picked[n] = true;
                foreach (var sol in Generate(index + 1))
                {
                    yield return sol;
                }
                _picked[n] = false;
            }
        }
    }
