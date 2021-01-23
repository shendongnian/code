    TheListBox.ItemContainerGenerator.StatusChanged += (sender, e) =>
    {
      TheListBox.Dispatcher.Invoke(() =>
      {
         var TheOne = TheListBox.ItemContainerGenerator.ContainerFromInsex(0);
           if (TheOne != null)
             // Use The One
      });
    };
