    MessageQueue sender = null;
    IAsyncResult result = null;
    var e = Activator.CreateInstance(typeof(System.Messaging.PeekCompletedEventArgs),
                                     BindingFlags.NonPublic | BindingFlags.Instance,
                                     null, new object[]{sender, result}, null);
