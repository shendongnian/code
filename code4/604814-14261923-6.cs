    internal void ScrollIntoView(ItemsControl.ItemInfo info)
        {
         if (this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            this.OnBringItemIntoView(info);
         else
            this.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (Delegate) new DispatcherOperationCallback(((ItemsControl) this).OnBringItemIntoView), (object) info);
        }
