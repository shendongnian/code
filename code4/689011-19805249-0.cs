    public class ARTImageControl : Control
    {
        public ARTImageControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;
            this.InternalScrollbarHorizontal = new HScrollBar();
            this.InternalScrollbarVertical = new VScrollBar();
            this.ScrollBarsVisibility = ScrollBarVisibility.Auto;
            this.ZoomToFit = false;
            this.ZoomFactor = 1.0;
            this.ZoomOnMouseWheel = true;
            this.BorderColor = Color.Black;
            this.BorderWidth = 1;
            this.BorderStyle = ButtonBorderStyle.Solid;
            this.PixelOffsetMode = PixelOffsetMode.Half;
            this.SmoothingMode = SmoothingMode.None;
            this.InterpolationMode = InterpolationMode.NearestNeighbor;
            this.ActiveTool = ARTImageControlToolType.Pan;
            Resize += ARTImageControl_Resize;
            MouseMove += ARTImageControl_MouseMove;
            MouseDown += ARTImageControl_MouseDown;
            MouseWheel += ARTImageControl_MouseWheel;
        }
        protected void UpdateSizeDrawing()
        {
            this.SizeDrawing = new Size(Convert.ToInt32(this.Width / this.ZoomFactor), Convert.ToInt32(this.Height / this.ZoomFactor));
        }
        protected HScrollBar InternalScrollbarHorizontal { get; set; }
        protected VScrollBar InternalScrollbarVertical { get; set; }
        public ScrollBarVisibility ScrollBarsVisibility { get; set; }
        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            if (this.Image != null)
            {
                e.Graphics.PixelOffsetMode = this.PixelOffsetMode;
                e.Graphics.SmoothingMode = this.SmoothingMode;
                e.Graphics.InterpolationMode = this.InterpolationMode;
                if (this.ZoomToFit)
                {
                    this.RectangleSource = new Rectangle(0, 0, this.Image.Width, this.Image.Height);
                }
                else
                {
                    this.RectangleSource = new Rectangle(this.InternalPointDrawingOrigin, this.SizeDrawing);
                }
                Rectangle rectangleDestination = new Rectangle(this.BorderWidth, this.BorderWidth, this.RectangleDestination.Width - 2 * this.BorderWidth, this.RectangleDestination.Height - 2 * this.BorderWidth);
                e.Graphics.DrawImage(this.Image, rectangleDestination, this.RectangleSource, GraphicsUnit.Pixel);
            }
            if ((this.BorderWidth > 0) && (this.BorderStyle != ButtonBorderStyle.None))
            {
                ControlPaint.DrawBorder(e.Graphics, this.RectangleDestination,
                                        this.BorderColor, this.BorderWidth, this.BorderStyle,
                                        this.BorderColor, this.BorderWidth, this.BorderStyle,
                                        this.BorderColor, this.BorderWidth, this.BorderStyle,
                                        this.BorderColor, this.BorderWidth, this.BorderStyle);
            }
            //base.OnPaint(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            this.RectangleDestination = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            this.UpdateSizeDrawing();
            base.OnSizeChanged(e);
            this.Invalidate();
        }
        #endregion
        #region Methods
        public void ZoomFitToClient()
        {
            if (this.Image != null)
            {
                this.ZoomToFit = false;
                this.ZoomFactor = Math.Min(ClientSize.Width / InternalImage.Width, ClientSize.Height / InternalImage.Height);
            }
        }
        public void ZoomIn()
        {
            this.ZoomFactor *= 1.1f;
        }
        public void ZoomOut()
        {
            this.ZoomFactor *= 0.9f;
        }
        protected void CheckBoundaries()
        {
            if (this.Image != null)
            {
                Int32 boundaryX = this.Image.Width - Convert.ToInt32(this.ClientSize.Width / this.ZoomFactor);
                Int32 boundaryY = this.Image.Height - Convert.ToInt32(this.ClientSize.Height / this.ZoomFactor);
                if (InternalPointDrawingOrigin.X > boundaryX)
                {
                    this.InternalPointDrawingOrigin = new Point(boundaryX, this.InternalPointDrawingOrigin.Y);
                }
                if (InternalPointDrawingOrigin.Y > boundaryY)
                {
                    this.InternalPointDrawingOrigin = new Point(this.InternalPointDrawingOrigin.X, boundaryY);
                }
                if (InternalPointDrawingOrigin.X < 0)
                {
                    this.InternalPointDrawingOrigin = new Point(0, this.InternalPointDrawingOrigin.Y);
                }
                if (InternalPointDrawingOrigin.Y < 0)
                {
                    this.InternalPointDrawingOrigin = new Point(this.InternalPointDrawingOrigin.X, 0);
                }
            }
        }
        #endregion
        #region Properties
        protected Image InternalImage { get; set; }
        public Image Image
        {
            get { return this.InternalImage; }
            set
            {
                if (value != null)
                {
                    if (this.InternalImage != null)
                    {
                        this.InternalImage.Dispose();
                        this.InternalPointDrawingOrigin = new Point(0, 0);
                        this.ZoomFactor = 1;
                        GC.Collect();
                    }
                    Rectangle rectangle = new Rectangle(0, 0, value.Width, value.Height);
                    this.InternalImage = new Bitmap(value).Clone(rectangle, PixelFormat.Format32bppPArgb);
                    this.Invalidate();
                }
                else
                {
                    this.InternalImage = null;
                    this.Invalidate();
                }
            }
        }
        public PixelOffsetMode PixelOffsetMode { get; set; }
        public SmoothingMode SmoothingMode { get; set; }
        public InterpolationMode InterpolationMode { get; set; }
        protected Double InternalZoomFactor { get; set; }
        public Double ZoomFactor
        {
            get { return this.InternalZoomFactor; }
            set
            {
                this.InternalZoomFactor = value;
                if (this.InternalZoomFactor > 15)
                {
                    this.InternalZoomFactor = 15;
                }
                if (this.InternalZoomFactor < 0.05)
                {
                    this.InternalZoomFactor = 0.05;
                }
                if ((this.Image != null))
                {
                    this.UpdateSizeDrawing();
                    this.CheckBoundaries();
                }
                this.Invalidate();
            }
        }
        public Boolean InternalZoomToFit { get; set; }
        public Boolean ZoomToFit
        {
            get { return this.InternalZoomToFit; }
            set
            {
                this.InternalZoomToFit = value;
                this.Invalidate();
            }
        }
        public ButtonBorderStyle BorderStyle { get; set; }
        public Byte BorderWidth { get; set; }
        public Color BorderColor { get; set; }
        public Boolean DoubleBuffering
        {
            get { return this.DoubleBuffered; }
            set { this.DoubleBuffered = value; }
        }
        protected Point InternalPointMouseDownStart { get; set; }
        protected Point InternalPointDrawingOrigin { get; set; }
        protected Rectangle RectangleSource { get; set; }
        protected Rectangle RectangleDestination { get; set; }
        protected Size SizeDrawing { get; set; }
        public Boolean ZoomOnMouseWheel { get; set; }
        #endregion
        #region Events
        private void ARTImageControl_Resize(Object sender, EventArgs e)
        {
            this.UpdateSizeDrawing();
            if (this.ZoomToFit)
            {
                this.Invalidate();
            }
        }
        private void ARTImageControl_MouseDown(Object sender, MouseEventArgs e)
        {
            if (this.InternalImage != null)
            {
                this.InternalPointMouseDownStart = new Point(e.X, e.Y);
                this.Focus();
            }
        }
        private void ARTImageControl_MouseMove(Object sender, MouseEventArgs e)
        {
            if (this.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.ActiveTool == ARTImageControlToolType.Pan)
                    {
                        Int32 DeltaX = InternalPointMouseDownStart.X - e.X;
                        Int32 DeltaY = InternalPointMouseDownStart.Y - e.Y;
                        Int32 pointOriginX = Convert.ToInt32(InternalPointDrawingOrigin.X + (DeltaX / InternalZoomFactor));
                        Int32 pointOriginY = Convert.ToInt32(InternalPointDrawingOrigin.Y + (DeltaY / InternalZoomFactor));
                        this.InternalPointDrawingOrigin = new Point(pointOriginX, pointOriginY);
                        this.CheckBoundaries();
                        this.InternalPointMouseDownStart = new Point(e.X, e.Y);
                    }
                    else
                    {
                    }
                    this.Invalidate();
                }
            }
        }
        private void ARTImageControl_MouseWheel(Object sender, MouseEventArgs e)
        {
            if (ZoomOnMouseWheel)
            {
                if (e.Delta > 0)
                {
                    this.ZoomIn();
                }
                else if (e.Delta < 0)
                {
                    this.ZoomOut();
                }
            }
        }
        #endregion
        public ARTImageControlToolType ActiveTool { get; set; }
    }
    public enum ARTImageControlToolType
    {
        Pan = 0,
        Rectangle = 1,
    }
    public abstract class ARTShape
    {
        public String Name { get; protected set; }
        public abstract Rectangle GetBoundingRectangle();
    }
    public class ARTRectangle : ARTShape
    {
        public ARTRectangle(UInt32 width, UInt32 height)
        {
            this.Width = width;
            this.Height = height;
        }
        public UInt32 Width { get; protected set; }
        public UInt32 Height { get; protected set; }
        public override Rectangle GetBoundingRectangle()
        {
            throw new NotImplementedException();
        }
        public Color ColorInactive { get; protected set; }
        public Color ColorActive { get; protected set; }
    }
    public enum ScrollBarVisibility
    {
        Auto = 0,
        Always = 1,
        Never = 2,
    }
