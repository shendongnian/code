        public class CustomArc : GMapMarker, ISerializable {
        [NonSerialized]
        public Pen pen;
        private int radius = 20;
        private int pen_width = 2;
        private float start = 0.0f;
        private float sweep = 0.0f;
        private GPoint ptA;
        private GPoint ptB;
        private GPoint ptC;
        private List<PointF> points;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public CustomArc(GPoint ptA, GPoint ptB, GPoint ptC, PointLatLng geo) : base(geo) {
            this.ptA = ptA;
            this.ptB = ptB;
            this.ptC = ptC;
            initialise();
        }
        private void initialise() {
            this.pen = new Pen(Brushes.White, this.pen_width);
            this.radius = (int)UIMaths.distance(ptC, ptA);
            this.points = new List<PointF>();
            if (ptA == ptB) {
                this.sweep = 360.0f;
            } else {
                // Calculate the radius
                this.sweep = (float)UIMaths.sweepAngleDeg(ptA, ptB, ptC);
            }
            this.start = (float)UIMaths.startAngle(ptC, ptB);
            Size = new Size(2 * radius, 2 * radius);
            Offset = new Point(-Size.Width / 2, -Size.Height / 2);
            Console.Out.WriteLine("Radius {0}, Start {1:0.0}, Sweep {2:0.0}", radius, start, sweep);
        }
        public override void OnRender(Graphics g) {
            try {
                Rectangle rect = new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);
                g.DrawArc(pen, rect, start, sweep);
            } catch (ArgumentException ex) {
                logger.Error(ex.Message);
            }
        }
        public sealed override void Dispose() {
            if (pen != null) {
                pen.Dispose();
                pen = null;
            }
            base.Dispose();
        }
        #region ISerializable Members
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);
        }
        protected CustomArc(SerializationInfo info, StreamingContext context)
         : base(info, context) {
        }
        #endregion
    }
