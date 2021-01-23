     public static readonly DependencyProperty ApplicationDataContextProperty =
                DependencyProperty.Register("ApplicationDataContext",
                typeof(Object),
                typeof(MyControl),
                new PropertyMetadata(MyControl_DataContextChanged));
    
    // my constructor
    
            public MyControl()
            {
    
                    InitializeComponent();
    
                    if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                    {
                        SetBinding(ApplicationDataContextProperty, new Binding());
                    }
    
            }
    
    // my event
            private static void MyControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
    
                    MyControl thisControl = sender as MyControl
                    if (thisControl != null)
                    {
                        INotifyPropertyChanged propertyChanged;
                        propertyChanged = e.OldValue as INotifyPropertyChanged;
                        if (propertyChanged != null)
                            propertyChanged.PropertyChanged -= thisControl.propertyChanged_PropertyChanged;
    
    
                        propertyChanged = e.NewValue as INotifyPropertyChanged;
                        if (propertyChanged != null)
                            propertyChanged.PropertyChanged += thisControl.propertyChanged_PropertyChanged;
                    }
    
            }
    
    // my 2e event
            void propertyChanged_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
    
                    if (e.PropertyName == "ListWithUsers")
                        LoadGrid();
    
    
            }
