        public class HighScore
        {
            public int Score
            {
                get;
                set;
            }
    
            public string Name
            {
                get;
                set;
            }
        }
    
        public class HighScoreCollection : List<HighScore>
        {
            public void SaveToXml(string fileName)
            {
                using (XmlWriter writer = XmlWriter.Create(fileName))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(HighScoreCollection));
                    ser.Serialize(writer, this);
                    writer.Flush();
                    writer.Close();
                }
            }
        }
