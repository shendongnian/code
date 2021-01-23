    public void Tap_Handler(object sender, GestureEventArgs e)
    {
        var item = (sender as Grid).DataContext as City; // Given you have City objects in your list
        NavigationContext.Navigate(new Uri("/View/City.xaml?id=" + item.Id, UriKind.Relative);
    }
