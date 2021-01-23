        public Form1()
        {
            InitializeComponent();
            splitContainer1.MouseMove += splitContainer1_MouseMove;
            splitContainer1.KeyDown += splitContainer1_KeyDown;
            splitContainer1.MouseDown += splitContainer1_MouseDown;
        }
        void splitContainer1_MouseDown(object sender, MouseEventArgs e)
        {
            splitContainer1.IsSplitterFixed = false;
        }
        void splitContainer1_MouseMove(object sender, MouseEventArgs e)
        {
            splitContainer1.IsSplitterFixed = false;
        }
        void splitContainer1_KeyDown(object sender, KeyEventArgs e)
        {
            splitContainer1.IsSplitterFixed = true;
        }
