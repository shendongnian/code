    var viewModel = new MainWindowViewModel();
            // As service is generic and don't know whether it can request close event
            var window = new Window() { Content = new MainView() };
            var closeable = viewModel as ICloseable;
            if (closeable != null)
            {
                closeable.CloseRequested += (s, e) => window.Close();
            }
