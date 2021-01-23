        [Test]
        public void Test()
        {
            CookieContainer cookies = new CookieContainer();
            cookies.Add(new Cookie("name1", "value1", "/", "www.domain1.com"));
            cookies.Add(new Cookie("name2", "value2", "/", "www.domain2.com"));
            Hashtable table = (Hashtable)cookies.GetType().InvokeMember("m_domainTable",
                                                                         BindingFlags.NonPublic |
                                                                         BindingFlags.GetField |
                                                                         BindingFlags.Instance,
                                                                         null,
                                                                         cookies,
                                                                         new object[] { });
            foreach (var key in table.Keys)
            {
                foreach (Cookie cookie in cookies.GetCookies(new Uri(string.Format("http://{0}/", key.ToString().Substring(1,key.ToString().Length - 1)))))
                {
                    Assert.That(cookie != null);
                    //Console.WriteLine("Name = {0} ; Value = {1} ; Domain = {2}", cookie.Name, cookie.Value,
                    //                  cookie.Domain);
                }
            }
            
        }
