    internal object OnBringItemIntoView(ItemsControl.ItemInfo info)
        {
          FrameworkElement frameworkElement = info.Container as FrameworkElement;
          if (frameworkElement != null)
            frameworkElement.BringIntoView();
          else if ((info = this.LeaseItemInfo(info, true)).Index >= 0)
          {
            VirtualizingPanel virtualizingPanel = this.ItemsHost as VirtualizingPanel;
            if (virtualizingPanel != null)
              virtualizingPanel.BringIndexIntoView(info.Index);
          }
          return (object) null;
        }
