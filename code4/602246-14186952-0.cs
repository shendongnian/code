            var doc = new XmlDocument();
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(xml)))
            {
                var settings = new XmlReaderSettings();
                // The default is 0, but setting it here allows us to document exactly why we are taking this approach.
                settings.MaxCharactersFromEntities = 0;
                using (var reader = XmlReader.Create(stream, settings))
                {
                    doc.Load(reader);
                }
            }
