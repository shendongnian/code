    private void imgPayment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
        {
            try
            {
                label1.Content = "df";
            }
            catch
            {
                lostfocs ld = new lostfocs(up);
              //  ld.Invoke("df");
                object obj=new object();
                ld.Invoke("sdaf");
            }
        }
    ));
