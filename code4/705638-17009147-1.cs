    private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ChargementAvion c = new ChargementAvion();
            c.OnDone += ResultsHandler;
            c.Show();
        }
    
      public void ResultsHandler(string result)
      {
         //do what you want ;)
      }
