    private void listBoxPopular_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int aux = 0;
        var app = (Application.Current as App);
        var selectedViewModel = listBoxPopular.SelectedItem as XYViewModel; 
           
        if (selectedViewModel != null)
              app.URI = selectedViewModel.Url ?? String.Empty;     
        ApplicationBarra(aux);
        ApplicationBar.Mode = ApplicationBarMode.Default;
    }
