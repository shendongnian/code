    var button = new UIButton (new RectangleF (0, 0, 25, 25));
    button.SetImage (new UIImage ("image"), UIControlState.Normal);
    var buttonItem = new UIBarButtonItem (button);
    buttonItem.SetTitleTextAttributes(...);
    NavigationItem.LeftBarButtonItem = buttonItem;
