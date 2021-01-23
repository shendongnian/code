    Thread thread = new Thread(new ThreadStart(() =>
            {
                vm.Dispatcher = Dispatcher.CurrentDispatcher;
                ev.Set();
                Dispatcher.CurrentDispatcher.BeginInvoke(new MethodInvoker(() =>
                {
                    SplashForm splashForm = new SplashForm(imageStream, imageSize)
                    {
                        DataContext = vm
                    };
                    splashForm.Show();
                }), new object[0]);
                Dispatcher.Run();
            }));
