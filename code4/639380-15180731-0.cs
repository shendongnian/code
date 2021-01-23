    private void clicked(object sender, RoutedEventArgs e)
    {
        draw();
        if (flag)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    draw();
                });
            });
        }
    }
