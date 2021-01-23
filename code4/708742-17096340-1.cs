    public class ParameterCollection
    {
        private Dictionary<string, string> _parms = new Dictionary<string, string>();
        public void Add(string key, string val)
        {
            if (_parms.ContainsKey(key))
            {
                throw new InvalidOperationException(string.Format("The key {0} already exists.", key));
            }
            _parms.Add(key, val);
        }
        public override string ToString()
        {
            var server = HttpContext.Current.Server;
            var sb = new StringBuilder();
            foreach (var kvp in _parms)
            {
                if (sb.Length > 0) { sb.Append("&"); }
                sb.AppendFormat("{0}={1}",
                    server.UrlEncode(kvp.Key),
                    server.UrlEncode(kvp.Value));
            }
            return sb.ToString();
        }
    }
