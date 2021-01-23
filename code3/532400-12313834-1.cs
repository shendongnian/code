     private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            #region username stuff
            string benutzername = textBox_benutzername.ToString();
            string passwort = textBox_passwort.ToString();
            passwort = changeString(passwort);
            benutzername = changeString(benutzername);
            #endregion username stuff
            // get the first cookie
            CookieContainer cookies = new CookieContainer();
            CookieContainer cookieContainer = new CookieContainer();
            HttpWebRequest sessionRequest = (HttpWebRequest)WebRequest.Create("http://www.bodytel.com/");
            sessionRequest.CookieContainer = new CookieContainer();
            cookies = sessionRequest.CookieContainer;
            HttpWebResponse sessionResponse = (HttpWebResponse)sessionRequest.GetResponse();
            sessionResponse.Close();
            // login 
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://secure.bodytel.com/de/mybodytel.html");
            req.CookieContainer = cookieContainer;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] byteArray = Encoding.ASCII.GetBytes("login=" + benutzername + "&password=" + passwort + "&step=login");
            req.ContentLength = byteArray.Length;
            Stream newStream = req.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            // now connect to the other link
            req = (HttpWebRequest)HttpWebRequest.Create("https://secure.bodytel.com/de/mybodytel/settings.html");
            req.CookieContainer = cookieContainer;
            req.Method = "GET";
            res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            string source = sr.ReadToEnd();
            StreamWriter myWriter = File.CreateText(@"C:\Users\nicholas\Documents\Visual Studio 2010\Projects\BodytelConnection\BodytelConnection\bin\\Debug\test.txt");
            myWriter.Write(source);
            myWriter.Close();
            res.Close();
        }
