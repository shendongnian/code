    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public struct POINTAPI
        {
            public Int32 X;
            public Int32 Y;
        }
        public struct MINMAXINFO
        {
            public POINTAPI ptReserved;
            public POINTAPI ptMaxSize;
            public POINTAPI ptMaxPosition;
            public POINTAPI ptMinTrackSize;
            public POINTAPI ptMaxTrackSize;
        }
        public const Int32 WM_GETMINMAXINFO = 0x24;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_GETMINMAXINFO:
                    MINMAXINFO mmi = (MINMAXINFO)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
                    mmi.ptMaxSize.X = this.Width;
                    mmi.ptMaxSize.Y = this.Height;
                    mmi.ptMaxPosition.X = this.Location.X;
                    mmi.ptMaxPosition.Y = this.Location.Y;
                    System.Runtime.InteropServices.Marshal.StructureToPtr(mmi, m.LParam, true);
                    break;
            }
            base.WndProc(ref m);
        }
    }
