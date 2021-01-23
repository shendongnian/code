    using System.Linq;
    using DotRas;
    RasConnection conn = RasConnection.GetActiveConnections().Where(o => o.EntryName == "My Entry").FirstOrDefault();
    if (conn != null)
    {
        conn.HangUp();
    }
