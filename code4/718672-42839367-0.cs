        /// <summary>
        /// Gets the description, stored in this attribute, reading from the resource using the cultureInfo defined by the language!
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns>Description for the given language if found; the default Description or ressourceKey otherwise</returns>
        public string GetDescription(string language)
        {
            return resource.GetStringFromResourceForLanguage(resourceKey, language, Description);
        }
        public static string GetStringFromResourceForLanguage(this ResourceManager resourceManager, string resourceKey, string language, string defaultValue = null)
        {
            if (string.IsNullOrEmpty(defaultValue))
                defaultValue = resourceKey;
            try
            {
                CultureInfo culture = CultureInfo.GetCultureInfo(language);
                string displayName = resourceManager.GetString(resourceKey, culture);
                return !string.IsNullOrEmpty(displayName) ? displayName : defaultValue;
            }
            catch // any, not only CultureNotFoundException
            {
                return defaultValue;
            }
        }
