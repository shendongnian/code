    if (dummy == A )
    {
        contentGrid.Dispatcher.BeginInvoke(new Action(() =>
        {
            var NEWVIEW = new  VIEW1();
            contentGrid.Children.Add(NEWVIEW);
        }));
    }
