    public override string ToString()
        {
            string sData = "";
            using (MemoryStream oStream = new MemoryStream())
            {
                XmlSerializer oSerializer = new XmlSerializer(this.GetType());
                oSerializer.Serialize(oStream, this);
                oStream.Position = 0;
                sData = Encoding.UTF8.GetString(oStream.ToArray());
            }
            return sData;
        }
