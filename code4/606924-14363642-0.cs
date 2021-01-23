    class MikesFlipView : FlipView
    {
 
    protected override void PrepareContainerForItemOverride
        (Windows.UI.Xaml.DependencyObject element, object item)
    {
      base.PrepareContainerForItemOverride(element, item);
 
      UserControl userControl = GetFirstChildOfType<UserControl>(element);
 
      if (userControl != null)
      {
        userControl.DataContext = item;
 
        var panel = GetFirstChildOfType<WrapPanel>(userControl);
        panel.Children.Clear();
 
        foreach (var img in ((ItemViewModel)item).Photo)
          AddChildren(img, panel);
      }
    }
 
    // this method is used to add children to the controls inside FlipView
    private void AddChildren(KeyValuePair<string, ItemPhoto> img, WrapPanel panel)
    {
      ...
    }
 
    private static T GetFirstChildOfType<T>(DependencyObject dobj)
     where T : DependencyObject
    {
      T retVal = null;
      int numKids = VisualTreeHelper.GetChildrenCount(dobj);
      for (int i = 0; i < numKids; ++i)
      {
        DependencyObject child = VisualTreeHelper.GetChild(dobj, i);
        if (child is T)
        { 
          retVal = (T)child;
        }
        else
        {
          retVal = GetFirstChildOfType<T>(child);
        }
 
        if (retVal != null)
        {
          break;
        }
      }
 
      return retVal;
    } 
    }
