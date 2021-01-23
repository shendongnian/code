    private void doSomething()
    {
        // ... bla bla bla
        colorBitmap = new WriteableBitmap(/* parameters */);
        colorBitmap.Freeze();
        Application.Current.Dispatcher.Invoke((Action)delegate
        {
            myImage.Source = colorBitmap;
        });
    }
