    Task.Factory.StartNew(() =>
    {
      for (int i = 0; i < 10; i++)
      {
         Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, 
            new Action(() => {listBox1.Items.Add("Number cities in problem = " + i.ToString()); }));
         System.Threading.Thread.Sleep(1000);
      }
    });
