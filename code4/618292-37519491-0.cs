    public class ShowFadingTextBehavior : System.Windows.Interactivity.Behavior<TextBlock>
    {
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
          "Duration", typeof(TimeSpan), typeof(ShowFadingTextBehavior), new PropertyMetadata(TimeSpan.FromSeconds(5)));
        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof (string), typeof (ShowFadingTextBehavior), new PropertyMetadata("",OnTextChanged));
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
            var b = (ShowFadingTextBehavior) d;
            var text = (string) e.NewValue;
            if(string.IsNullOrEmpty(text))
                return;
            b.Show(text);
        }
        private void Show(string text)
        {
            var textBlock = AssociatedObject;
            if(textBlock==null)
                return;
            textBlock.Text = text;
            if(textBlock.Visibility==Visibility.Visible)
                return;
            textBlock.Visibility = Visibility.Visible;
            var a = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(1),
                Duration = new Duration(Duration)
            };
            var storyboard = new Storyboard();
            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, textBlock);
            Storyboard.SetTargetProperty(a, new PropertyPath(UIElement.OpacityProperty));
            storyboard.Completed += delegate
            {
                textBlock.Visibility = Visibility.Collapsed;
                textBlock.Opacity = 1.0;
                var binding = BindingOperations.GetBinding(this, TextProperty);
                if(binding==null)
                    return;
                ClearValue(TextProperty);
                BindingOperations.SetBinding(this, TextProperty, binding);
            };
            storyboard.Begin();
           
        }
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
