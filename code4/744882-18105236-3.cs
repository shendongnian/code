    private async Task start(string IP, string Port)
    {
        if (!bIsConnected && !isListening)
        {
            //This Line Will Make UI Freez...
            bIsConnected =  await Task.Run(()=>axCZKEM1.Connect_Net(IP, Convert.ToInt32(Port)));
    ...
