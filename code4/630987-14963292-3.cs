      public partial class MainWindow : Window
        {
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
    
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                timer.Interval = TimeSpan.FromSeconds(3);
                timer.Tick += timer_Tick;
                timer.Start();
    
                sb = new Storyboard();
            }
            int n = 0;
            bool isWorking;
            Storyboard sb;
            void timer_Tick(object sender, EventArgs e)
            {
                if (isWorking == false)
                {
                    isWorking = true;
                    try
                    {
                        var myElement = stackObj.Children[n];
    
                        var dur = TimeSpan.FromMilliseconds(2000);
    
                        var f = CreateVisibility(dur, myElement, false);
    
                        sb.Children.Add(f);
    
                        Duration d = TimeSpan.FromSeconds(2);
                        DoubleAnimation DA = new DoubleAnimation() { From = 1, To = 0, Duration = d };
    
                        sb.Children.Add(DA);
                        string myObjectName = "r" + n;
                        Storyboard.SetTargetName(DA, myObjectName);
    
                        Storyboard.SetTargetProperty(DA, new PropertyPath("Opacity"));
    
                        sb.Begin(this);
    
                        n++;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + "   " + DateTime.Now.TimeOfDay);
                    }
    
                    isWorking = false;
                }
            }
    
            private static ObjectAnimationUsingKeyFrames CreateVisibility(Duration duration, UIElement element, bool show)
            {
                var _Two = new DiscreteObjectKeyFrame { KeyTime = new TimeSpan(duration.TimeSpan.Ticks / 2), Value = (show ? Visibility.Visible : Visibility.Collapsed) };
    
                var _Animation = new ObjectAnimationUsingKeyFrames { BeginTime = new TimeSpan(0) };
                _Animation.KeyFrames.Add(_Two);
                Storyboard.SetTargetProperty(_Animation, new PropertyPath("Visibility"));
                Storyboard.SetTarget(_Animation, element);
                return _Animation;
            }
    
        }
