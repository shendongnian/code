    var handler = Pickedimage;
    if(handler != null) {
        foreach (EventHandler<GameEventArgs> subscriber in
            handler.GetInvocationList())
        {
            try {
                subscriber(this, e);
            } catch (Exception ex) {
                Trace(ex);
            }
        }
    }
