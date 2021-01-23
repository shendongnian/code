    public void LoadApplication()
        {
            ShowProgress= true;
            if (AuthenticateUser)
            {
                var dispatcher = Dispatcher.CurrentDispatcher;
                dispatcher.Invoke(new Action(() =>
                {
                    MainWindow objMainWindow = new MainWindow();
                    objMainWindow.Show();
                    Application.Current.MainWindow.Close();
                }
            }
            ShowProgress= false;
        }
