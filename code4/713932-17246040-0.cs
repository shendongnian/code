    public static Task<Resultado> AutenticarUsuarioAsync(this RestAPI api)
    {
        var tcs = new TaskCompletionSource<Resultado>();
    
        api.AutenticarUsuarioFinalizado += (sender, args) =>
        {
            if (args.Error)
                tcs.TrySetException(new SomeAppropriateException());
            else
                tcs.TrySetResult(args.Resultado);
        };
    
        api.AutenticarUsuario();
    
        return tcs.Task;
    }
    
    …
    
    private async void LogInButton_Click(object sender, RoutedEventArgs e)
    {
        var api = new RestAPI(
            "http://localhost:2624/", UsernameTextBox.Text,
            PasswordTextBox.Password);
    
        ProgressBar.Visibility = Visibility.Visible;
        ProgressBar.IsIndeterminate = true;
        LogInButton.IsEnabled = false;
    
        try
        {
            var resultado = await api.AutenticarUsuarioAsync();
            if (resultado.Autenticado)
            {
                // whatever
            }
        }
        catch (SomeAppropriateException ex)
        {
            // handle the exception here
        }
        finally
        {
            ProgressBar.IsIndeterminate = false;
            ProgressBar.Visibility = Visibility.Collapsed;
            LogInButton.IsEnabled = true;
        }
    }
