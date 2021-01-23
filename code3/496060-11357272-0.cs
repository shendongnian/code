            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string html = reader.ReadToEnd();
                    Console.WriteLine("Parsing {0}", html);
                    Regex regex = new Regex("href=\\\"([^\\\"]*)", RegexOptions.IgnoreCase);
                    MatchCollection matches = regex.Matches(html);
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            if (match.Success)
                            {
                                Console.WriteLine("Found {0}", match.Captures[0]);
                            }
                        }
                    }
                }
            }
