        public static async dbObj Login(String username, String password)
        {
            dbObj ret = new dbObj();
            String rawWebReturn = "";
            ret.propBag.Add(_BAGTYPE, returnTypes.Login.ToString());
            DateTime date = DateTime.Now;
            WebClient wc = new WebClient();
            try
            {
                var result = await wc.DownloadStringTaskAsync(new Uri(baseLoginURI + "uname=" + username + "&pword=" + password + "&date=" + date.ToString()));
                return parseWebReturn(result, ret);
            }
            catch (Exception e)
            {
                return parseWebReturn(e.Message, ret);
            }
        }
