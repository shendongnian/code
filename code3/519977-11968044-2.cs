    public partial class MyProgressBar : UserControl
        {
            public MyProgressBar()
            {
                InitializeComponent();
    
                Loaded += new RoutedEventHandler(MyProgressBar_Loaded);
            }
    
            void MyProgressBar_Loaded(object sender, RoutedEventArgs e)
            {
                Update();
            }
    
            private static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(MyProgressBar), new PropertyMetadata(100d, OnMaximumChanged));
            public double Maximum
            {
                get { return (double)GetValue(MaximumProperty); }
                set { SetValue(MaximumProperty, value); }
            }
    
    
            private static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(MyProgressBar), new PropertyMetadata(0d, OnMinimumChanged));
            public double Minimum
            {
                get { return (double)GetValue(MinimumProperty); }
                set { SetValue(MinimumProperty, value); }
            }
    
            private static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(MyProgressBar), new PropertyMetadata(50d, OnValueChanged));
            public double Value
            {
                get { return (double)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
    
    
    
            private static readonly DependencyProperty ProgressBarWidthProperty = DependencyProperty.Register("ProgressBarWidth", typeof(double), typeof(MyProgressBar), null);
            private double ProgressBarWidth
            {
                get { return (double)GetValue(ProgressBarWidthProperty); }
                set { SetValue(ProgressBarWidthProperty, value); }
            }
    
            static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                (o as MyProgressBar).Update();
            }
    
            static void OnMinimumChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                (o as MyProgressBar).Update();
            }
    
            static void OnMaximumChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                (o as MyProgressBar).Update();
            }
    
    
            void Update()
            {
                // The -2 is for the borders - there are probably better ways of doing this since you
                // may want your template to have variable bits like border width etc which you'd use
                // TemplateBinding for
                ProgressBarWidth = Math.Min((Value / (Maximum + Minimum) * this.ActualWidth) - 2, this.ActualWidth - 2);
    
                
            }          
        }
