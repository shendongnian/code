     public static readonly DependencyProperty SomeProperty = DependencyProperty.Register("Some", typeof (SomeValue), typeof (YourUserControl), new PropertyMetadata(default(SomeValue)));
    
            public SomeValue Some
            {
                get { return (SomeValue) GetValue(SomeProperty); }
                set { SetValue(SomeProperty, value); }
            }
