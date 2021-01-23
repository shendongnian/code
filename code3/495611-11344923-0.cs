            var chapters = new List<string>();
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                reader.ReadToFollowing("CHAPTER");
                reader.MoveToFirstAttribute();
                string chapterNumber = reader.Value;
                chapters.Add("Chapter " + chapterNumber);
            }
