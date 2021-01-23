    public partial class Form1 : Form
    {
        public const int WM_MOVING = 0x216;
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        private int OriginalY = 0;
        private int OriginalHeight = 0;
        private bool HorizontalMovementOnly = true;
        public Form1()
        {
            InitializeComponent();
            this.Shown += new EventHandler(Form1_Shown);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            this.Move += new EventHandler(Form1_Move);
        }
        void Form1_Move(object sender, EventArgs e)
        {
            this.SaveValues();
        }
        void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.SaveValues();
        }
        void Form1_Shown(object sender, EventArgs e)
        {
            this.SaveValues();
        }
        private void SaveValues()
        {
            this.OriginalY = this.Location.Y;
            this.OriginalHeight = this.Size.Height;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MOVING:
                    if (this.HorizontalMovementOnly)
                    {
                        RECT rect = (RECT)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(RECT));
                        rect.Top = this.OriginalY;
                        rect.Bottom = rect.Top + this.OriginalHeight;
                        System.Runtime.InteropServices.Marshal.StructureToPtr(rect, m.LParam, false);
                    }
                    break;
            }
            base.WndProc(ref m);            
        }
    }
