            Thread thread = new Thread(() =>
            {
                while (!formClosed)
                {
                    if (!Process.GetProcesses().Any(x => x.MainWindow.Title.Contains(windowName)))
                    {
                        //form closed, call your web service
                    }
                    Thread.Sleep(5000);
                }
            });
