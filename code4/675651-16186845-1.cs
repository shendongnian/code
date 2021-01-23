    Thread thread = new Thread(new ThreadStart(() =>
            {
                vm.Dispatcher = Dispatcher.CurrentDispatcher;
                ev.Set();
                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new MethodInvoker(() =>
                {
                    SplashForm splashForm = new SplashForm(imageStream, imageSize)
                    {
                        DataContext = vm
                    };
                    splashForm.Show();
                }));
                Dispatcher.Run();
            }));
