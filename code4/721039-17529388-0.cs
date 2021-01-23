        public string SetPreference(string username, string path, string value)
        {
            var prefs = GetPreferences(username);
            var jprefs = JObject.Parse(prefs ?? @"{}");
            var token = jprefs.SelectToken(path) as JValue;
            if (token == null)
            {
                var jpart = jprefs;
                foreach(var part in path.Split('.'))
                {
                    if(jpart[part] == null)
                        jpart.Add(new JProperty(part, new JObject()));
                    jpart = jpart[part] as JObject;
                }
                jpart.Replace(new JValue(value));
            }
            else
                token.Value = value;
            SetPreferences(username, jprefs.ToString());
            return jprefs.SelectToken(path).ToString();
        }
