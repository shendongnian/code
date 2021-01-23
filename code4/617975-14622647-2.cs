    private void fixScrollBarBug()
    {
      ScrollBar scrollBar = GetChildByName<ScrollBar>(myDataGrid, "PART_HorizontalScrollBar");
      if (scrollBar != null)
      {
        if (VisualTreeHelper.GetChildrenCount(scrollBar) > 0)
        {
          Grid grid = (Grid)VisualTreeHelper.GetChild(scrollBar, 0);
          if (VisualTreeHelper.GetChildrenCount(grid) == 3)
          {
            try
            {
              RepeatButton leftButton = (RepeatButton)VisualTreeHelper.GetChild(grid, 0);
              RepeatButton rightButton = (RepeatButton)VisualTreeHelper.GetChild(grid, 2);
              AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(rightButton);
              if (automationPeer == null)
                automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(rightButton);
              IInvokeProvider provider = automationPeer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
              provider.Invoke();
              automationPeer = FrameworkElementAutomationPeer.FromElement(leftButton);
              if (automationPeer == null)
                automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(leftButton);
              provider = automationPeer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
              provider.Invoke();
            }
            catch { }
          }
        }
      }
    }
