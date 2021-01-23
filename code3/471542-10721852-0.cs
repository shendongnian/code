      void TemplateSelector_Loaded(object sender, RoutedEventArgs e)
            {
                showWin();
    
                Thread.Sleep(10000);
    
    
                CloseWin();
    
            }
    
            private void CloseWin()
            {
                WindowManager.Close();
            }
            Window tempWindow = new Window();
            public void showWin()
            {
                WindowManager.LaunchWindowNewThread<SplashWindow>();
    
            }
        }
    
        public class WindowManager
        {
            private static Window win;
            public static void LaunchWindowNewThread<T>() where T : Window, new()
            {
                Thread newWindowThread = new Thread(ThreadStartingPoint);
                newWindowThread.SetApartmentState(ApartmentState.STA);
                newWindowThread.IsBackground = true;
    
                Func<Window> f = delegate
                {
                    T win = new T();
                    return win;
                };
    
                newWindowThread.Start(f);
            }
    
            private static void ThreadStartingPoint(object t)
            {
                Func<Window> f = (Func<Window>)t;
                win = f();
    
                win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                win.Topmost = true;
                win.Show();
                Dispatcher.Run();
            }
            public static void Close()
            {
    
                if (win != null)
                    win.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Send);
    
            }
        }
