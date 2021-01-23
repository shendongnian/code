    public struct ConnectionData
    {
        public string Host;
        public ushort Port;
        public static bool TryParse(string connectionString, out ConnectionData data)
        {
            data = default(ConnectionData);
            try { data = Parse(connectionString); return true; }
            catch (FormatException) { return false; }
        }
        public static ConnectionData Parse(string connectionString)
        {
            var data = new ConnectionData();
            var parts = connectionString.Split(new char[] { ':' }, 2);
            if (parts.Length != 2 || !ushort.TryParse(parts[1], out data.Port))
                throw new FormatException("Provided connectionString was not in the correct format of 'host:port'");
            data.Host = parts[0];
            return data;
        }
    };
