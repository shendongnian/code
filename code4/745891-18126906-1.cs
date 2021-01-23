        public void PARSEVALUES(string jsonValue)//jsonValue contains your json
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            RootObject r = jss.Deserialize<RootObject>(jsonValue);
            foreach (var tweetText in r.statuses)
            {
                string val = tweetText.text;
            }
        }
