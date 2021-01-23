            public String Title
        {
            get { return (String)base.GetValue(TitleProperty); }
            set { base.SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
         DependencyProperty.RegisterAttached(
             "Title",
             typeof(String),
             typeof(UserControl1),
             new FrameworkPropertyMetadata(null)
             );
