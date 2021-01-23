    public static string PingThatAddress(string hostAddress)
    {
        try
        {
            Ping ping = new Ping();
            PingReply pingreply = ping.Send(hostAddress);
            if (pingreply != null && pingreply.Status.ToString() != "TimedOut")
            {
                return "Address: " + pingreply.Address + "\r"
                     + "Roundtrip Time: " + pingreply.RoundtripTime + "\r"
                     + "TTL (Time To Live): " + pingreply.Options.Ttl + "\r"
                     + "Buffer Size: " + pingreply.Buffer.Length + "\r";
            }
            else
            {
                return string.Empty;
            }
        }
        catch (Exception pingError)
        {
            Debug.Fail(pingError.Message + " " + pingError);
            return string.Empty;
        }
    }
