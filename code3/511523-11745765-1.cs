          public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            void ContinueAnimation()
            {
                ModelList list = Resources["ModelList"] as ModelList;
                if ( list.CurrentIndex < (list.Count -1))
                {
                    list.CurrentIndex += 1;
                    Storyboard b = Resources["FadeOut"] as Storyboard;
                    b.Begin();
                }
            }
    
            private void Start_Click(object sender, RoutedEventArgs e)
            {
                ContinueAnimation();
            }
    
            private void FadeOut_Completed(object sender, EventArgs e)
            {
                ContinueAnimation();    
            }
    
        }
