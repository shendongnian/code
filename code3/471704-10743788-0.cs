         public static readonly DependencyProperty captionLabelVisibilityProperty = DependencyProperty.Register(
                                                                                        "CaptionVisibility",
                                                                                        typeof(Visibility),
                                                                                        typeof(MyContainerControl),
                                                                                        new FrameworkPropertyMetadata(
                                                                                            VisibilityPropertyChangedCallback));
        public Visibility CaptionVisibility
        {
            get
            { return (Visibility)GetValue(captionLabelVisibilityProperty); }
            set
            { SetValue(captionLabelVisibilityProperty, value); }
        }
        
        private static void VisibilityPropertyChangedCallback(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
        {
            MyContainerControl myContainerControlInstance = (MyContainerControl)controlInstance;
            myContainerControlInstance.myLabel.Visibility = (Visibility)args.NewValue;
        }
