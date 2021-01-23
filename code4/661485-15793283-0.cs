    public MyPage()
    {
        CoreWindow.GetForCurrentThread().KeyDown += MyPage_KeyDown;
    }
    void MyPage_KeyDown(CoreWindow sender, KeyEventArgs args)
    {
        Debug.WriteLine(args.VirtualKey.ToString());
    }
