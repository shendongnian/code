     public async void ButtonClick(object sender, RoutedEventArgs args)
     {
         Connection result = await restClient.Connect(this.UserId.Text, this.Password.Text);
          //... do something with result
     }
