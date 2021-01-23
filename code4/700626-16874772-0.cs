    // The following code was written by Guilherme Labigalini
    public partial class BlockedProgressBar : Control
    {
        BlockList _blockList;
        /// <summary>
        /// MyProgressBar Constructor
        /// </summary>
        public BlockedProgressBar()
        {
            InitializeComponent();
            _blockList = new BlockList();
            _direction = DirectionMode.Horizontal;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);
        }
        /// <summary>
        /// Update mode of segments
        /// </summary>
        [Description("The mode of update of progress bar")]
        [Category("MyProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public BlockList.UpdateMode UpdateMode
        {
            get { return _blockList.Update; }
            set { _blockList.Update = value; }
        }
        /// <summary>
        /// Change quantity of segments
        /// </summary>
        [Description("The length of segments of progress bar")]
        [Category("MyProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Length
        {
            get { return _blockList.Length; }
            set { _blockList.Length = value; this.Refresh(); }
        }
        /// <summary>
        /// Get or set filled segments 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[] FilledSegments
        {
            get { return _blockList.FilledSegments; }
            set { _blockList.FilledSegments = value; this.Refresh(); }
        }
        /// <summary>
        /// Get or sets the full list of segments
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool[] FullListSegment
        {
            get { return _blockList.FullListSegment; }
            set { _blockList.FullListSegment = value; this.Refresh(); }
        }
        /// <summary>
        /// Get or set the block list of segments
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Block> BlockList
        {
            get { return _blockList.List; }
            set { _blockList.List = value; this.Refresh(); }
        }
        /// <summary>
        /// DirectionMode of bar
        /// </summary>
        public enum DirectionMode
        {
            Horizontal = 0,
            Vertical = 1
        }
        private DirectionMode _direction = DirectionMode.Horizontal;
        /// <summary>
        /// Horizontal or Vertical
        /// </summary>
        [Description("The filling direction of progress bar")]
        [Category("MyProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public DirectionMode Direction
        {
            get { return _direction; }
            set { _direction = value; this.Refresh(); }
        }
        /// <summary>
        /// OnPaint event
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Color color1 = ControlPaint.Dark(this.ForeColor);
            Color color2 = ControlPaint.Light(this.ForeColor);
            if (_direction == DirectionMode.Horizontal)
            {
                int top = ClientRectangle.Top + ClientRectangle.Height / 2 - 1;
                int height = ClientRectangle.Height - top;
                DrawRectangleH(pe, top, height, color2, color1);
                top = ClientRectangle.Top;
                height = ClientRectangle.Height / 2;
                DrawRectangleH(pe, top, height, color1, color2);
            }
            else
            {
                int left = ClientRectangle.Left;
                int width = ClientRectangle.Width / 2;
                DrawRectangleV(pe, left, width, color1, color2);
                left = ClientRectangle.Left + ClientRectangle.Width / 2;
                width = ClientRectangle.Width / 2;
                DrawRectangleV(pe, left, width, color2, color1);
            }
            pe.Graphics.DrawRectangle(new Pen(Color.Black), ClientRectangle);
            base.OnPaint(pe);
        }
        private void DrawRectangleH(PaintEventArgs pe, int top, int height, Color fromColor, Color toColor)
        {
            var rect = new Rectangle(ClientRectangle.Left, top, ClientRectangle.Width, height);
            var brush = new LinearGradientBrush(rect, fromColor, toColor, LinearGradientMode.Vertical);
            if (_blockList.Length > 0)
            {
                Rectangle[] rects = GetRectanglesH(top, height);
                if (rects.Length > 0) pe.Graphics.FillRectangles(brush, rects); //SystemBrushes.Control
            }
        }
        private void DrawRectangleV(PaintEventArgs pe, int left, int width, Color fromColor, Color toColor)
        {
            var rect = new Rectangle(left, ClientRectangle.Top, width, ClientRectangle.Height);
            var brush = new LinearGradientBrush(rect, fromColor, toColor, LinearGradientMode.Horizontal);
            if (_blockList.Length > 0)
            {
                Rectangle[] rects = GetRectanglesV(left, width);
                if (rects.Length > 0) pe.Graphics.FillRectangles(brush, rects); //SystemBrushes.Control
            }
        }
        private Rectangle[] GetRectanglesH(int top, int height)
        {
            var rects = new List<Rectangle>();
            float xf = 0;
            int y = top;
            int h = height;
            float pf = this.Width / (float)_blockList.Length;
            //h = this.Height;
            foreach (Block block in _blockList.List)
            {
                if (block.PercentProgress > 0)
                {
                    int x = Convert.ToInt32(xf);
                    float wf = (pf * (block.BlockSize * block.PercentProgress / 100)) + xf - x;
                    int w = Convert.ToInt32(wf);
                    rects.Add(new Rectangle(x, y, w, h));
                }
                xf += pf * block.BlockSize;
            }
            return rects.ToArray();
        }
        private Rectangle[] GetRectanglesV(int left, int width)
        {
            var rects = new List<Rectangle>();
            float yf = 0;
            int x = left;
            int w = width;
            float pf = this.Height / (float)_blockList.Length;
            //w = this.Width;
            foreach (Block block in _blockList.List)
            {
                if (block.PercentProgress > 0)
                {
                    int y = Convert.ToInt32(yf);
                    float hf = (pf * (block.BlockSize * block.PercentProgress / 100)) + yf - y;
                    int h = Convert.ToInt32(hf);
                    rects.Add(new Rectangle(x, y, w, h));
                }
                yf += pf * block.BlockSize;
            }
            return rects.ToArray();
        }
    }
    [Serializable]
    public class BlockList
    {
        private int _length;
        private List<Block> _blockList;
        public BlockList()
        {
            _blockList = new List<Block>();
        }
        public enum UpdateMode
        {
            All,
            FilledSegments,
            FullListSegment,
            BlockList
        }
        /// <summary>
        /// Update mode of segments
        /// </summary>
        public UpdateMode Update = UpdateMode.All;
        /// <summary>
        /// Change quantity of segments
        /// </summary>
        public int Length
        {
            get { return _length; }
            set
            {
                if (_length != value && value > 0)
                {
                    var bools = FullListSegment;
                    var bools2 = new bool[value];
                    for (int i = 0; i < bools.Length; i++)
                    {
                        bools2[i] = bools[i];
                    }
                    FullListSegment = bools2;
                }
            }
        }
        /// <summary>
        /// Get or set filled segments 
        /// </summary>
        public int[] FilledSegments
        {
            get
            {
                var bools = FullListSegment;
                var filled = new List<int>();
                for (int i = 0; i < bools.Length; i++)
                {
                    if (bools[i])
                    {
                        filled.Add(i);
                    }
                    
                }
                return filled.ToArray();
            }
            set
            {
                if (Update != UpdateMode.All && Update != UpdateMode.FilledSegments)
                    throw new InvalidOperationException();
                if (value != null)
                    if (value.Length > 0)
                    {
                        var bools = FullListSegment;
                        for (int i = 0; i < value.Length; i++)
                        {
                            bools.SetValue(true, value[i]);
                        }
                        FullListSegment = bools;
                    }
            }
        }
        /// <summary>
        /// Get or sets the full list of segments
        /// </summary>
        public bool[] FullListSegment
        {
            get
            {
                int sizeAnterior = 0;
                var bools = new bool[_length];
                if (bools.Length > 0)
                {
                    foreach (Block block in _blockList)
                    {
                        for (int i = 0; i < Convert.ToInt32(block.BlockSize * block.PercentProgress / 100); i++)
                            bools.SetValue(true, i + sizeAnterior);
                        sizeAnterior += Convert.ToInt32(block.BlockSize);
                    }
                }
                return bools;
            }
            set
            {
                if (Update != UpdateMode.All && Update != UpdateMode.FullListSegment)
                    throw new InvalidOperationException();
                bool bOld = false;
                int qtd = 0;
                int filled = 0;
                if (value != null)
                {
                    if (value.Length > 0)
                    {
                        _blockList.Clear();
                        float percent;
                        foreach (bool b in value)
                        {
                            if (b == bOld)
                                qtd++;
                            else
                            {
                                if (bOld)
                                    filled = qtd;
                                else if (filled + qtd > 0)
                                {
                                    percent = filled / (float)(filled + qtd) * 100;
                                    _blockList.Add(new Block(filled + qtd, percent));
                                }
                                qtd = 1;
                                bOld = b;
                            }
                        }
                        if (filled + qtd > 0)
                        {
                            percent = filled / (float)(filled + qtd) * 100;
                            _blockList.Add(new Block(filled + qtd, percent));
                        }
                        _length = value.Length;
                    }
                }
                else
                {
                    _length = 0;
                }
            }
        }
        /// <summary>
        /// Get or set the block list of segments
        /// </summary>
        public List<Block> List
        {
            get
            {
                return _blockList;
            }
            set
            {
                if (Update != UpdateMode.All && Update != UpdateMode.BlockList)
                    throw new InvalidOperationException();
                float size = 0;
                _blockList = value;
                if (_blockList != null)
                    size += _blockList.Sum(block => block.BlockSize);
                _length = Convert.ToInt32(size);
            }
        }
    }
    [Serializable]
    public class Block
    {
        private float _blockSize;
        private float _percentProgress;
        public Block(float blockSize, float percentProgress)
        {
            this.BlockSize = blockSize;
            this.PercentProgress = percentProgress;
        }
        public float BlockSize
        {
            get { return _blockSize; }
            set { _blockSize = value; }
        }
        public float PercentProgress
        {
            get { return _percentProgress; }
            set { _percentProgress = value; }
        }
    }
