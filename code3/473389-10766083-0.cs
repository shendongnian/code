    LoopThroughControls(LayoutRoot);
    
    private void LoopThroughControls(UIElement parent)
    {
      int count = VisualTreeHelper.GetChildrenCount(parent);
      if (count > 0)
      {
        for (int i = 0; i < count; i++)
        {
          UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);
          string childTypeName = child.GetType().ToString();
          LoopThroughControls(child);
        }
      }
    } 
