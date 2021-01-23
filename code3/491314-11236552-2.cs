    private static System.Collections.Generic.Dictionary<String, String> ConvertDataToDictionary(string data)
        {
            char amp = '&';
            string[] nameValuePairs = data.Split(amp);
            System.Collections.Generic.Dictionary<String, String> dict = new System.Collections.Generic.Dictionary<string, string>();
            char eq = '=';
            for (int x = 0; x < nameValuePairs.Length; x++)
            {
                string[] tmp = nameValuePairs[x].Split(eq);
                dict.Add(tmp[0], HttpUtility.UrlDecode(tmp[1]));
            }
            return dict;
        }
