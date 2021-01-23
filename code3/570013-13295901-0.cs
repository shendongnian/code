    public string DataOrientation
       {
           get { return (string)GetValue(DataOrientationProperty); }
           set { SetValue(DataOrientationProperty, value); }
       }
    
       /// <summary>
       /// Identifies the DataOrientation dependency property.
       /// </summary>
       public static readonly DependencyProperty DataOrientationProperty =
           DependencyProperty.Register(
               "DataOrientation",
               typeof(string),
               typeof(MyClass),
               new PropertyMetadata("Horizontal",  // Default to Horizontal; Can use string.Empty
                                     OnDataOrientationPropertyChanged));
    
       /// <summary>
       /// DataOrientationProperty property changed handler.
       /// </summary>
       /// <param name="d">MyClass that changed its DataOrientation.</param>
       /// <param name="e">Event arguments.</param>
       private static void OnDataOrientationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
       {
           MyClass source = d as MyClass;  // Put breakpoint here.
           string value = (string)e.NewValue;
       }
