    /// <summary>
    /// Tries to locate a given item within the visual tree,
    /// starting with the dependency object at a given position. 
    /// </summary>
    /// <typeparam name="T">The type of the element to be found
    /// on the visual tree of the element at the given location.</typeparam>
    /// <param name="reference">The main element which is used to perform
    /// hit testing.</param>
    /// <param name="point">The position to be evaluated on the origin.</param>
    public static T TryFindFromPoint<T>(UIElement reference, Point point)
      where T : DependencyObject
    {
      DependencyObject element = reference.InputHitTest(point)
                                   as DependencyObject;
      if (element == null) return null;
      else if (element is T) return (T)element;
      else return TryFindParent<T>(element);
    }
