       using (XmlReader reader = XmlReader.Create("c:\\your.xml"))
        {
            reader.MoveToContent();
            reader.ReadToDescendant("rowset");
            var serializer = new XmlSerializer(typeof(CharacterList));
            var list = (CharacterList)serializer.Deserialize(reader);
        }
