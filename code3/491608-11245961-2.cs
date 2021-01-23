     public partial class MainWindow : Window , IWindow
        {
            public MainWindow()
            {
                InitializeComponent();
        
            }
    
       
    
            public new int Left
            {
                get
                {
                    return Left;
                }
                set
                {
                    Left = value;
                }
            }
    
            public int Right
            {
                get
                {
                    return Right;
                }
                set
                {
                    Left = value;
                }
            }
    
            public void ShowWindow()
            {
                Show();
            }
        }
