    public static class ScrollViewerBinding
    {
      #region VerticalOffset attached property
     
      /// <summary>
      /// Gets the vertical offset value
      /// </summary>
      public static double GetVerticalOffset(DependencyObject depObj)
      {
        return (double)depObj.GetValue(VerticalOffsetProperty);
      }
     
      /// <summary>
      /// Sets the vertical offset value
      /// </summary>
      public static void SetVerticalOffset(DependencyObject depObj, double value)
      {
        depObj.SetValue(VerticalOffsetProperty, value);
      }
     
      /// <summary>
      /// VerticalOffset attached property
      /// </summary>
      public static readonly DependencyProperty VerticalOffsetProperty =
          DependencyProperty.RegisterAttached("VerticalOffset", typeof(double),
          typeof(ScrollViewerBinding), 
    	new PropertyMetadata(0.0, OnVerticalOffsetPropertyChanged));
     
      #endregion
    }
