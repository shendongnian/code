        private Dictionary<string, Dictionary<string, string>> _localizations = new Dictionary<string, Dictionary<string, string>>();
        private string _currentLocalization = "English";
        private bool LoadLocalizations()
        {
            try
            {
                if (File.Exists("languagesSupported.xml") == false)
                {
                    return false;
                }
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("languagesSupported.xml");
                XmlNodeList nodeList = xmldoc.SelectNodes("languages/language");
                if (nodeList.Count > 0)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        LoadLocalization(node.Attributes["name"].Value, node.Attributes["file"].Value);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool LoadLocalization(string pLang, string pFile)
        {
            try
            {
                if (File.Exists(pFile) == false)
                {
                    return false;
                }
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(pFile);
                XmlNodeList nodeList = xmldoc.SelectNodes("language/localized");
                _localizations.Add(pLang, new Dictionary<string,string>());
                if (nodeList.Count > 0)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        _localizations[pLang].Add(node.Attributes["name"].Value, node.Attributes["value"].Value);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void SetLocalization()
        {
            labelHello.text = _localizations[_currentLocalization]["hello"];
            labelGoodbye.text = _localizations[_currentLocalization]["goodbye"];
        }
