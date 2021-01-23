    public partial class MyUserControl : UserControl
    {
        private MyFilter filter;
        public MyUserControl()
        {
            InitializeComponent();
            filter = new MyFilter();
            filter.LButtonScroll += new MyFilter.LBUTTONSCROLLDELEGATE(filter_LButtonScroll);
            Application.AddMessageFilter(filter);
        }
        private void filter_LButtonScroll()
        {
            Console.WriteLine("WM_MOUSEWHEEL while LBUTTONDOWN");
        }
        private class MyFilter : IMessageFilter
        {
            private bool LBUTTONDOWN = false;
            private const int WM_LBUTTONDOWN = 0x201;
            private const int WM_LBUTTONUP = 0x202;
            private const int WM_MOUSEWHEEL = 0x20a;
            public delegate void LBUTTONSCROLLDELEGATE();
            public event LBUTTONSCROLLDELEGATE LButtonScroll;
            public bool PreFilterMessage(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_LBUTTONDOWN:
                        LBUTTONDOWN = true;
                        break;
                    case WM_MOUSEWHEEL:
                        if (LBUTTONDOWN)
                        {
                            if (LButtonScroll != null)
                            {
                                LButtonScroll();
                            }
                        }
                        break;
                    case WM_LBUTTONUP:
                        LBUTTONDOWN = false;
                        break;
                }
                return false;
            }
        }
    }
