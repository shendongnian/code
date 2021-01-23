    for (int i = 0; i < targets.Count(); i++)
    {
        ...
        int j = i;
        pingSender.PingCompleted += (sender, e) =>
                                        {
                                            targets[j].PingReply = e.Reply; // <== j, not i
                                            finished.Signal();
                                        };
