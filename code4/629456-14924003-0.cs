    using System.Windows.Forms;
    using System.Drawing;
    using System.ComponentModel;
    public class TransparentLabel {
        
        public TransparentLabel() {
            //  This call is required by the designer.
            InitializeComponent();
            //  Add any initialization after the InitializeComponent() call.
            //  Add any initialization after the InitializeComponent() call.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.components = new System.ComponentModel.Container();
            RF = new RectangleF(0, 0, base.Width, base.Height);
            LabelForeColorBrush = new SolidBrush(base.ForeColor);
        }
        
        private StringFormat sFormat;
        
        private RectangleF RF;
        
        private SolidBrush LabelForeColorBrush = null;
        
        private void UpdateText() {
            try {
                sFormat = new StringFormat();
                int x = 0;
                int y = 0;
                // With...
                switch (TextAlignment) {
                    case ContentAlignment.BottomCenter:
                        sFormat.Alignment = StringAlignment.Center;
                        sFormat.LineAlignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.BottomLeft:
                        sFormat.Alignment = StringAlignment.Near;
                        sFormat.LineAlignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.BottomRight:
                        sFormat.Alignment = StringAlignment.Far;
                        sFormat.LineAlignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.MiddleLeft:
                        sFormat.Alignment = StringAlignment.Near;
                        sFormat.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.MiddleCenter:
                        sFormat.Alignment = StringAlignment.Center;
                        sFormat.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.MiddleRight:
                        sFormat.Alignment = StringAlignment.Far;
                        sFormat.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.TopCenter:
                        sFormat.Alignment = StringAlignment.Center;
                        sFormat.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopLeft:
                        sFormat.Alignment = StringAlignment.Near;
                        sFormat.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopRight:
                        sFormat.Alignment = StringAlignment.Far;
                        sFormat.LineAlignment = StringAlignment.Near;
                        break;
                }
                sFormat.FormatFlags = StringDirection;
                ResizeControl();
            }
            catch (Exception ex) {
            }
        }
        
        private void ResizeControl() {
            RF.Size = new Size(base.Size);
            Invalidate();
        }
        
        private StringFormatFlags _StringDirection = (StringFormatFlags.NoClip < Description("The Direction of the Text."));
        
        public StringFormatFlags StringDirection {
            get {
                return _StringDirection;
            }
            set {
                _StringDirection = value;
                UpdateText;
            }
        }
        
        private System.Drawing.ContentAlignment _TextAlignment = (ContentAlignment.MiddleCenter < Description("The Text Alignment that will appear on this control."));
        
        public System.Drawing.ContentAlignment TextAlignment {
            get {
                return _TextAlignment;
            }
            set {
                _TextAlignment = value;
                UpdateText();
            }
        }
        
        public override System.Drawing.Color ForeColor {
            get {
                return base.ForeColor;
            }
            set {
                base.ForeColor = value;
                LabelForeColorBrush = new SolidBrush(value);
            }
        }
        
        private string _Labeltext = ("TransparentLabel" < Description("The text to be displayed in supports with real transparency."));
        
        public string LabelText {
            get {
                return _Labeltext;
            }
            set {
                _Labeltext = value;
                Invalidate();
            }
        }
        
        [Browsable(false)]
        [EditorBrowsable(false)]
        public override System.Drawing.Color BackColor {
            get {
                return base.BackColor;
            }
            set {
                base.BackColor = value;
            }
        }
        
        protected override System.Windows.Forms.CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = (cp.ExStyle | 32);
                return cp;
            }
        }
        
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            try {
                base.OnPaint(e);
                //  draw the text on the control
                e.Graphics.DrawString(LabelText, base.Font, LabelForeColorBrush, RF, sFormat);
                //  MyBase.OnPaint(e)
            }
            catch (Exception ex) {
            }
        }
        
        private void TransparentLabel_Resize(object sender, System.EventArgs e) {
            ResizeControl();
        }
    }
