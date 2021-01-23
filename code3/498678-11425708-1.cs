    public static readonly DependencyProperty ViewModelProperty =
               DependencyProperty.Register("ViewModelH", typeof(ViewModel), typeof(KinectSkeleton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
      
    
      public ViewModel ViewModelH
        {
            get
            {
                return (ViewModel)GetValue(ViewModelProperty);
            }
            set
            {
                SetValue(ViewModelProperty, value);
            }
        }
