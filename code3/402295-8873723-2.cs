    public static string PingThatAddress(string hostAddress)
    {
        try
        {
            Ping ping = new Ping();
            PingReply pingreply = ping.Send(hostAddress);
            string result = string.Empty;
            if (pingreply != null && pingreply.Status.ToString() != "TimedOut")
            {
                result = "Address: " + pingreply.Address + "\r"
                     + "Roundtrip Time: " + pingreply.RoundtripTime + "\r"
                     + "TTL (Time To Live): " + pingreply.Options.Ttl + "\r"
                     + "Buffer Size: " + pingreply.Buffer.Length + "\r";
            }
            return result;
        }
        catch (Exception pingError)
        {
            Debug.Fail(pingError.Message + " " + pingError);
        }
        return string.Empty;
    }
