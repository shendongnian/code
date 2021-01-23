         private void OnCreateNewWindow(object sender, RoutedEventArgs e)
         {
           SynchronizationContext syncContext = SynchronizationContext.Current;
           var btn = sender as Button;
           var st = btn.Parent as StackPanel;
            
           Thread thread = new Thread(() =>
             {
                Button button = new Button();
                syncContext.Post(delegate { st.Children.Add(button) ;}, null); //Exception here
             });
            
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
         }
