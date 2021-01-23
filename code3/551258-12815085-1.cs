    public struct ConnectionData
    {
        public string Host;
        public ushort Port;
        private static Regex FORMAT = new Regex(@"^(?<host>\w+):(?<port>\d{1,5})$", RegexOptions.Compiled);
        public static bool TryParse(string connectionString, out ConnectionData data)
        {
            data = default(ConnectionData);
            try { data = Parse(connectionString); return true; }
            catch (FormatException) { return false; }
        }
        public static ConnectionData Parse(string connectionString)
        {
            var data = new ConnectionData();
            var match = FORMAT.Match(connectionString);
            if (!match.Success || !ushort.TryParse(match.Groups["port"].Value, out data.Port))
                throw new FormatException("Provided connectionString was not in the correct format of 'host:port'");
            data.Host = match.Groups["host"].Value;
            return data;
        }
    };
