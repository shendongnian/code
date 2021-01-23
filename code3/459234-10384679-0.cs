    label1.Content = "waiting...";
              
    label1.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate()
       {
            
            label1.UpdateLayout();
        }));
    
    System.Threading.Thread.Sleep(3000);
    label1.Content = "done!";
