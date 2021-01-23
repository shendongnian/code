    TheListBox.ItemContainerGenerator.StatusChanged += (sender, e) =>
    {
      TheListBox.Dispatcher.Invoke(() =>
      {
         var TheOne = TheListBox.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
           if (TheOne != null)
             // Use The One
      });
    };
