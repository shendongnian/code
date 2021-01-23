    public void AddChatter(ChattyClass chatter)
    {
        myChatters.Add(chatter);
        // Assign the event handler
        chatter.PropertyChanged += new PropertyChangedEventHandler(chatter_PropertyChanged);
    }
