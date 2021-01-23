        Timer t;
        public MainWindow()
        {
            InitializeComponent();
            t = new Timer(3000);
            t.Elapsed += t_Elapsed;
            
            
        }
        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            MessageBox.Show("Your mouse has been hovering for 3 seconds");
        }
        
        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Hovered");
            t.Start();
        }
        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            t.Stop();
        }
