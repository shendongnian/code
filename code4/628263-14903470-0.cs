               string[] array = webBrowser.Document.Cookie.Split(new char[]
							{
								';'
							});
                            for (int i = 0; i < array.Length; i++)
                            {
                                string cookie = array[i];
                                string name = cookie.Split(new char[]
								{
									'='
								})[0];
                                string value = cookie.Substring(name.Length + 1);
                                string path = "/";
                                string domain = "abc.com";
                                yummycookies.Add(new Cookie(name.Trim(), value.Trim(), path, domain));
                            }
