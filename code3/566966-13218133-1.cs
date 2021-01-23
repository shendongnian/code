    public struct HttpParam
    {
        private string _key;
        private string _value;
        public string Key { get { return HttpUtils.UrlEncode(_key); } set { _key = value; } }
        public string Value { get { return HttpUtils.UrlEncode(_value); } set { _value = value; } }
        public HttpParam(string key, string value)
        {
            _key = key;
            _value = value;
        }
        public override string ToString()
        {
            return string.Format("{0}={1}", Key, Value);
        }
    };
