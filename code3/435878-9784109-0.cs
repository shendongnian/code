    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject rootObject) where T : DependencyObject
    {
      if (rootObject != null)
      {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(rootObject); i++)
        {
          DependencyObject child = VisualTreeHelper.GetChild(rootObject, i);
          if (child != null && child is T)
            yield return (T)child;
          foreach (T childOfChild in FindVisualChildren<T>(child))
            yield return childOfChild;
        }
      }
    }
