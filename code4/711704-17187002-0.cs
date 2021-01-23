            public MainWindow()
            {
                InitializeComponent();
    
                System.Windows.Media.Animation.DoubleAnimation ani = new System.Windows.Media.Animation.DoubleAnimation();
                ani.Completed += new EventHandler(ani_Completed);
            }
    
            void ani_Completed(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
