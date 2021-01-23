        public MainWindow()
        {
            InitializeComponent();
            Image rotateImage = new Image()
            {
                Stretch = Stretch.Uniform,
                Source = new BitmapImage(new Uri("pack://application:,,,/Chrysanthemum.jpg")),
                RenderTransform = new RotateTransform()
            };
            Image opacityImage = new Image()
            {
                Stretch = Stretch.Uniform,
                Source = new BitmapImage(new Uri("pack://application:,,,/Desert.jpg"))
            };
            LayoutRoot.Children.Add(rotateImage);
            LayoutRoot.Children.Add(opacityImage);
            Grid.SetColumn(opacityImage, 1);
            Storyboard storyboard = new Storyboard();
            storyboard.Duration = new Duration(TimeSpan.FromSeconds(10.0));
            DoubleAnimation rotateAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 360,
                Duration = storyboard.Duration
            };
            DoubleAnimation opacityAnimation = new DoubleAnimation()
            {
                From = 1.0,
                To = 0.0,
                BeginTime = TimeSpan.FromSeconds(5.0),
                Duration = new Duration(TimeSpan.FromSeconds(5.0))
            };
            Storyboard.SetTarget(rotateAnimation, rotateImage);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            Storyboard.SetTarget(opacityAnimation, opacityImage);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(rotateAnimation);
            storyboard.Children.Add(opacityAnimation);
            Resources.Add("Storyboard", storyboard);
            Button button = new Button()
            {
                Content = "Begin"
            };
            button.Click += button_Click;
            Grid.SetRow(button, 1);
            Grid.SetColumnSpan(button, 2);
            LayoutRoot.Children.Add(button);
        }
        void button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["Storyboard"]).Begin();
        }
