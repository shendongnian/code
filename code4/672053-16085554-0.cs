    var newControl new ContentControl();
    newControl.ContentTemplate = Resource;
    Binding b = new Binding();
    b.ElementName = "TextBox";
    b.Path = new PropertyPath(".");
    myContentControl.SetBinding(ContentControl.ContentProperty, b);
