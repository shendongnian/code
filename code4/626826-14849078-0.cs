            XElement artists = xdoc.Root.Element("similarartists");
            if (artists != null)
            {
                IEnumerable<string> names = artists
                    .Elements("artist")
                    .Select(el => el.Element("name").Value);
            }
