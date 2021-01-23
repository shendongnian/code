        using (XmlReader reader = XmlReader.Create(new StringReader(e.Result)))
                {
                    reader.ReadToFollowing("link");
                    while (reader.Read())
                    {
                        .... read node logic ....
                         reader.ReadToNextSibling("link");
                    }                    
                }
