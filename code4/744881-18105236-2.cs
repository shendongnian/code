    private async Task start(string IP, string Port)
    {
        if (!bIsConnected && !isListening)
        {
            //This Line Will Make UI Freez...
            bIsConnected =  await axCZKEM1.Connect_NetAsync(IP, Convert.ToInt32(Port));
    ...
