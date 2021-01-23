        private void LoadHightLightRule()
        {
            using (Stream s = myAssembly.GetManifestResourceStream("Your_Assembly_Name.lua.xshd"))
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    Editor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
        }
