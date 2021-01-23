        public bool IsDropDownOpen
        {
         get { return (bool)GetValue(IsDropDownOpenProperty); }
         set { SetValue(IsDropDownOpenProperty, value); }
        }        
    
        public static readonly DependencyProperty IsDropDownOpenProperty =
              DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(Window), new UIPropertyMetadata(false));
