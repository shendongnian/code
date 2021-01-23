    private void Button_LogIn_Click(object sender, RoutedEventArgs e)
            {
                Internet net = new Internet();
                bool check = net.checkInternet();
    
                if (check.Equals(false))
                      return;
                    try
                    {
                        net.doRequest();
                    }
                    catch
                    {
                        //do not throw an error, instead just use the return keyword!
                        return;
                    }
                     
                        ClientServiceSoapClient web_service = new ClientServiceSoapClient();
                        web_service.LogInCompleted += new System.EventHandler<LogInCompletedEventArgs>(LogInComplete);
                        web_service.LogInAsync(TextBox_Username.Text, TextBox_Password.Password);
            }
