    Task<bool> t = Task.Run(() => client.ConnectAsync(ipAddr, port).Wait(1000));
    await t;
    if (!t.Result)
    {
       Console.WriteLine("Connect timed out");
       return; // Set/return an error code or throw here.
    }
    // Successful Connection - if we get to here.
