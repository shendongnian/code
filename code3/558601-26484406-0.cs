    var contentPresenter = new ContentPresenter { Content = new Button() };
    var contentControl = new ContentControl { Content = new Button() };
    if ((contentPresenter.Content as FrameworkElement).Parent == null)
        Debug.WriteLine("ContentPresenter won't let you get ancestors");
    if ((contentControl.Content as FrameworkElement).Parent != null)
        Debug.WriteLine("ContentControl will let you get ancestors");
