        [ConfigurationProperty("Paths")]
        [ConfigurationCollection(typeof(Paths), AddItemName = "Path")]
        public Paths Paths
        {
            get
            {
                var o = this["Paths"];
                return o as Paths;
            }
        }
