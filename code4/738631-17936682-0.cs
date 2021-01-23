    enter code here
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // change the background of stackpanel
            StackPanel st = new StackPanel();
            SolidColorBrush mysolidbrush = new SolidColorBrush();
            mysolidbrush.Color = Color.FromArgb(255, 100,100,10); // RGB color
            st.Background = mysolidbrush;
            
            // Adding textblock to the stackpanel 
            TextBlock txtblk = new TextBlock();
            st.Children.Add(txtblk);
        }
