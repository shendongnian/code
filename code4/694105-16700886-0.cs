            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            string key = "asd";
            var origValue = config.AppSettings.Settings[key];
            string newValue = origValue.Value + "changed";
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, newValue);
