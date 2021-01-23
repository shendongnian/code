            for (int i = 0; i < b.Headers.Count; i++)
            {
                string name = b.Headers.GetKey(i);
                string value = b.Headers.Get(i);
                if (name == "Set-Cookie")
                {
                    Match match = Regex.Match(value, "(.+?)=(.+?);");
                    if (match.Captures.Count > 0)
                    {
                        reqCookies.Add(new Cookie(name, value, "/", "domain.com"));
                    }
                }
            }
