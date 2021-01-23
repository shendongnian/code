        public static void StoreConfig(string content)
        {
            IEnumerable<string> strs = Split(content, 2000);
            int i = 1;
            foreach(var s in strs)
            {
                AppLocalSettings.Values["test" + (i++)] = s;
            }
            AppLocalSettings.Values["test_count"] =  i-1 +"";
        }
        public static string ReadConfig()
        {
            string s = "";
            int count = Convert.ToInt32(AppLocalSettings.Values["test_count"]);
            for(int i = 1; i<=count; i++)
            {
                s += Convert.ToString(AppLocalSettings.Values["test" + (i)]);
            }
            return s;
        }
