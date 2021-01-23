    using System.Net.NetworkInformation;
    var ping = new Ping();
    var reply = ping.Send("10.38.2.73", 60 * 1000); // 1 minute time out (in ms)
    if (reply.Status == IPStatus.Success)
    {
       Console.WriteLine("Server is up");
    }
    else
    {
       Console.WriteLine("Server is down");
    }
