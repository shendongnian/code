       string basestring = "?param[key1]=value1&param[key2]=value2";
            string newstring = basestring.Replace("?", "").Replace("param[", "").Replace("]", "");
            var array = newstring.Split('&');
            var dictionary = new Dictionary<string, string>();
            foreach (var onestring in array)
            {
                var splitedstr = onestring.Split('=');
                dictionary.Add(splitedstr[0],splitedstr[1]);
            }
