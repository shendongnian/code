        /// <summary>
        /// Gets a setting with the given name.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>Setting value or null if such setting does not exist.</returns>
        internal string GetSetting(string name)
        {
            Debug.Assert(!string.IsNullOrEmpty(name));
            string value = null;
            value = GetValue("ServiceRuntime", name, GetServiceRuntimeSetting);
            if (value == null)
            {
                value = GetValue("ConfigurationManager", name, n => ConfigurationManager.AppSettings[n]);
            }
            return value;
        }
