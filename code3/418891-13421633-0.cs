    public static readonly DependencyProperty CaptionProperty =          
         DependencyProperty.Register("Text",
                                            typeof(string),
                                            typeof(CtrpushPinContent),
                                            new PropertyMetadata(string.Empty, OnTextChanged));
        
            public string Text
            {
                get { return textBlock1.Text; }
                set { textBlock1.Text = value; }
            }
        
            private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                ((CtrpushPinContent)sender).textBlock1.Text = (string)e.NewValue;
            }
        
            public CtrpushPinContent()
            {
                InitializeComponent();
            }
