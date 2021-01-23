    private async Task loginAsync(string username, string password)
    {
          ServiceReference1.Service1SoapClient service = new ServiceReference1.Service1SoapClient();
          var response = await service.loginwebAsync(username, password);
    }
    private async void btnLogin_Click(object sender, RoutedEventArgs e)
    {
          string user = txtUsername.Text;
          string pass = txtPassword.Text;
          await loginAsync(user, pass);
    }
