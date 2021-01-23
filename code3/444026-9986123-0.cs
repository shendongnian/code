    ObservableCollection<T> Cast<T>(object obj, T typedobj)
    {
      return (ObservableCollection<T>)typedobj;
    }
    private void btnClockIn_Click(object sender, RoutedEventArgs e)
    {
      var temp = new 
      { 
        firstName = string.Empty, 
        lastName = string.Empty, 
        position = string.Empty, 
        clockInDate = DateTime.Min, 
        clockOutDate = DateTime.Now 
      };
      var collection = Cast(lstView1.DataContext, temp);
      collection.Add(...);
    }
