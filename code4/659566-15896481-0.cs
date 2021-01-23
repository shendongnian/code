      public static T FindAncestor<T>(DependencyObject dependencyObject)
            where T : class
         {
            DependencyObject target = dependencyObject;
            do
            {
                target = VisualTreeHelper.GetParent(target);
            }
            while (target != null && !(target is T));
            return target as T;
           }
