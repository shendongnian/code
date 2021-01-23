        //add dependency property
        public static DependencyProperty MyTestProperty;
        
        //init dependency property in static control constructor
        static MyControl()
        {
             var myTestPropertyMetadata = new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender, MyTestPropertyChanged);
                    MyTestProperty= DependencyProperty.Register("MyTest",
                                                           typeof(string),
                                                           typeof(MyControl),
                                                           myTestPropertyMetadata );
        }
       //implement property 
        public String MyTest
        {
            get { return (String)GetValue(MyTestProperty); }
            set
            {
                SetValue(MyTestProperty, value);
            }
        }
       //using in xaml
       <MyControls:MyControl MyTest="dfdsf" />
