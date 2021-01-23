    public static readonly DependencyProperty TestProperty =
           DependencyProperty.Register("Test",
              typeof(object), typeof(MyControl),
              new PropertyMetadata(null, TestChangedCallbackHandler));
        private static void TestChangedCallbackHandler(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            MyControl obj = sender as MyControl;
            Test = args.NewValue; 
        }
