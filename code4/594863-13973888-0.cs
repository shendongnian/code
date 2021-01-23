    for (UInt16 i = 0; i < networkedComputers.Count; i++) {
        int count = i;
        Task.Factory.StartNew(() => sm.RunServerMonitorPerMachine(networkedComputers[i].ToString());
    }
    Task.Factory.StartNew(() => dailyEvents());
