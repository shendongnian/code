        public void Set(List<AcmSettings> acmSettings)
        {
            XElement xelement = XElement.Load("Settings.xml");
            IEnumerable<XElement> settings = xelement.Elements();
            foreach (var item in acmSettings)
            {
                xelement.Descendants(item.Name).FirstOrDefault().Value = item.Value;
            }
            xelement.Save("Settings.xml");
        }
