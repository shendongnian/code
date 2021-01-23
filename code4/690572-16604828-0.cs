    Queue<...> messages = new Queue<...>();
    ...
    popupTimer.Tick += (sender, args) =>
    {
        if (messages.Count > 0) 
        {
            ... = messages.Dequeue();
        }
        else 
        {
            popupMessage.IsOpen = false;
            popupTimer.Stop();
        }
    };
