        // constructor
        private PageStyle(string item)
        {
            this.webDB = Sitecore.Configuration.Factory.GetDatabase("web");
            this.item = webDB.Items[item];
        }
        public static PageStyle GetInstance(string item)
        {
                lock (lockObject)
                {
                    if (_Instance == null)
                        _Instance = new PageStyle(item);
                }
                return _Instance;
        }
