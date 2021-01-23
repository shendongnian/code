    private void OnCreateNewWindow( object sender,   RoutedEventArgs e)
    {
     Thread thread = new Thread(() =>
    {
     Window1 w = new Window1();
     w.Show();
     w.Closed += (sender2, e2) =>
      w.Dispatcher.InvokeShutdown();
     System.Windows.Threading.Dispatcher.Run();
    });
     thread.SetApartmentState(ApartmentState.STA);
     thread.Start();
    }
