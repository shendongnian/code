    public static DependencyProperty GridColorProperty = DependencyProperty.Register("GridColor", typeof (Brush),
                                                                                             typeof (UserControl1),
                                                                                             new FrameworkPropertyMetadata(
                                                                                                 null,
                                                                                                 FrameworkPropertyMetadataOptions
                                                                                                     .AffectsRender));
            public Brush GridColor
            {
                get { return (Brush)GetValue(GridColorProperty); }
                set { SetValue(GridColorProperty, value);}
            } 
