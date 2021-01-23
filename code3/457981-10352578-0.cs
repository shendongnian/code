    static class FrameworkElementExtensions {
      public T FindName<T>(this FrameworkElement parent, String name) {
        var child = parent.FindName(name);
        if (child == null)
          throw new ArgumentException(
            String.Format("No element named '{0}' exists.", name);
        var typedChild = child as T;
        if (typedChild == null)
          throw new ArgumentException(
            String.Format("Named element '{0}' has wrong type.", name);
        return typedChild;
      }
    }
