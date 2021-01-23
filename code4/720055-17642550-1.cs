    private void ButtonZoom_OnClick(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(() =>
            {
                var i = 0;
                while (i++ < 100)
                {
                    var i1 = i;
                    //var i1 = (-0.00092)*(i*i) + (0.092)*i + 0.2;
                    Dispatcher.Invoke(new Action(() =>
                        {
                            if (i1 < 10 || i1 > 90)
                            {
                                ImageMain.Height += 0.5;
                                ImageMain.Width += 0.5;
                            }
                            else if (i1 < 30 || i1 > 70)
                            {
                                ImageMain.Height += 1;
                                ImageMain.Width += 1;
                            }
                            else
                            {
                                ImageMain.Height += 3;
                                ImageMain.Width += 3;
                            }
                        }));
                    Thread.Sleep(30);
                }
    
            });
    }
