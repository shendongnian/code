    private void onItemContainerGeneratorStatusChanged(object sender, EventArgs e)
    {
      if (((ItemContainerGenerator)sender).Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
      {
        ScrollViewer sv = GetVisualChild<ScrollViewer>(myDataGrid);
        if (sv != null)
        {
          AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(sv);
          if (automationPeer == null)
            automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(sv);
          IScrollProvider provider = automationPeer.GetPattern(PatternInterface.Scroll) as IScrollProvider;
          try { provider.Scroll(ScrollAmount.SmallIncrement, ScrollAmount.NoAmount); }
          catch { }
          try { provider.Scroll(ScrollAmount.SmallDecrement, ScrollAmount.NoAmount); }
          catch { }
        }
      }
    }
