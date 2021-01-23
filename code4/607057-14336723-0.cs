    public class Marquee : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer timer1;
        private int currentPos = 0;
        private bool mBorder;
        private string mText;
        public string MarqueeText
        {
            get { return mText; }
            set { mText = value; }
        }
        public bool Border
        {
            get { return mBorder; }
            set { mBorder = value; }
        }
        public int Interval
        {
            get { return timer1.Interval * 10; }
            set { timer1.Interval = value / 10; }
        }
        public Marquee()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitForm call
            this.Size = new Size(this.Width, this.Font.Height);
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Marquee
            // 
            this.Name = "Marquee";
            this.Size = new System.Drawing.Size(150, 136);
            this.Resize += new System.EventHandler(this.Marquee_Resize);
        }
        #endregion
        private void Marquee_Resize(object sender, System.EventArgs e)
        {
            this.Height = this.Font.Height;
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            
            if (mBorder)
            {
                e.Graphics.DrawRectangle(new Pen(this.ForeColor), 0, 0, this.Width - 1, this.Height - 1);
            }
           
            float dif = e.Graphics.MeasureString(mText, this.Font).Width- this.Width;
            if (this.Width < e.Graphics.MeasureString(mText, this.Font).Width)
            {
                e.Graphics.DrawString(mText, this.Font, new SolidBrush(this.ForeColor),
                    currentPos, 0);
                e.Graphics.DrawString(mText, this.Font, new SolidBrush(this.ForeColor),
                    this.Width + currentPos + dif, 0);
                currentPos--;
                if ((currentPos < 0) && (Math.Abs(currentPos) >= e.Graphics.MeasureString(mText, this.Font).Width))
                    currentPos = this.Width + currentPos;
            }
            else 
            {
                e.Graphics.DrawString(mText, this.Font, new SolidBrush(this.ForeColor),-dif/2, 0);
            }
            
        }
    }
