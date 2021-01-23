    void Exec(string proxy,string url)
    {
        var th = new Thread(() =>
        {
            SetProxy(proxy);
            using (WebBrowser wb = new WebBrowser())
            {
                wb.DocumentCompleted += (sndr, e) =>
                {
                    ExecuteRoutine();
                    Application.ExitThread();
                };
                wb.Navigate(url);
                Application.Run();
            }
        });
        th.SetApartmentState(ApartmentState.STA);
        th.Start();
        th.Join();
    }
