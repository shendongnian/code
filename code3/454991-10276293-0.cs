        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //add some bootstrap or startup logic 
            var identity = AuthService.Login();
            if (identity == null)
            {
                LoginWindow login = new LoginWindow();
                login.Show();
            }
            else
            {
                MainWindow mainView = new MainWindow();
                mainView.Show();
            }
        }
