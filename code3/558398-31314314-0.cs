        var json1 = DecodeHex(json);
        var jsonDes = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json1);
        public static string DecodeHex(string data)
        {
            data = data.Replace("\\x22", @"""");
            data = data.Replace("\\x23", "#");
        .......
        }
