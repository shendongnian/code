    public string getRowKey(string topic, string rk)
    {
        return string.Join("", from s in topic.Split('.')
                               select s.PadLeft(2, '0')).PadRight(4, '0') +
                    (string.IsNullOrEmpty(rk) ? "" : rk.Substring(4));
    }
