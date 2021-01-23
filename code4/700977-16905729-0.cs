    private static Dictionary<string, string> _sharedDictionary = new Dictionary<string, string>();
    public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            if (runKind == WizardRunKind.AsMultiProject)
            {
                try
                {                    
                    _sharedDictionary.Add("$connectionString$", connectionString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (_sharedDictionary != null)
            {
                foreach (KeyValuePair<string, string> dictItem in _sharedDictionary)
                {
                    if (!replacementsDictionary.ContainsKey(dictItem.Key))
                    {
                        replacementsDictionary.Add(dictItem.Key, dictItem.Value);
                    }
                }
            }
        }
