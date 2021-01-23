        public delegate void Method();
        private static Method close;
        public Form1()
        {
            InitializeComponent();
            close = new Method(Close);
        }
        public static void CloseForm()
        {
            close.Invoke();
        }
