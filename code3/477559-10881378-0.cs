    GestureListener listener = new GestureListener();
    listener.Tap += (sender, args) =>
            {
                   // some logic here
            };
    this.browser.SetValue(GestureService.GestureListenerProperty, listener);
