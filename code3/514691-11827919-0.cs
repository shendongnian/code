      new Thread(() =>
      {
          if (cb.Dispatcher.CheckAccess())
            {
               list.Add("Zoop");
            }
          else
           {
            cb.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(delegate 
                             {
                               list.Add("Zoop");
                             }
           ));
           }
      }).Start();
