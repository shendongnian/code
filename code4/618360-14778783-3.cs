        /// Non-static constructor
        public SunkenBorder()
        {
            // Avoid Visual Studio 2010 designer errors
            if (IsVisualStudio2010DesignerRunning())
                return;
            // Expression Blend 4's designer displays previews of animations 
            //  that these event handlers initiate!
            Initialized += new EventHandler(SunkenBorder_Initialized);
            Loaded += new RoutedEventHandler(SunkenBorder_Loaded);
            Unloaded += new RoutedEventHandler(SunkenBorder_Unloaded);
            IsVisibleChanged += new DependencyPropertyChangedEventHandler(SunkenBorder_IsVisibleChanged);
        }
        // ...
        /// Used to set the initial VSM state (its the first opportunity).
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (IsVisualStudio2010DesignerRunning())
            {
                // set a property just to illustrate that this targets only Visual Studio 2010:
                this.Background = Brushes.Blue;
                // return before doing VisualState change so Visual Studio's designer won't crash
                return;
            }
            // Blend 4 executes this at design-time just fine
            VisualStateManager.GoToState(this, "InitialState", false);
            // ...
        }
      
