                while (_pageContentReader.Read())
                {
                    if (_pageContentReader.Name == "Glyphs")
                    {
                        if (_pageContentReader.HasAttributes)
                        {
                            if (_pageContentReader.GetAttribute("UnicodeString") != null)
                            {
                               _resultingtext=_pageContentReader.GetAttribute("UnicodeString"));
                            }
                        }
                    }
                }
            }`
