        private CultureInfo cachedCulture;
        private string cachedDisplayName;
        public override string DisplayName
        {
            get
            {
                var culture = CultureInfo.CurrentCulture;
                if (culture != cachedCulture)
                {
                    cachedDisplayName = GetMessageFromResource(base.DisplayName);
                    cachedCulture = culture;
                }
                return cachedDisplayName;
            }
        }
