    [Serializable()]
    class salesman
    {
        public string name, address, email;
        public int sales;
    }
    class salesmenCollection 
    {
       List<salesman> salesmanList;
       public void SaveTo(string path){
           System.IO.File.WriteAllText (path, this.ToString());
       }    
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
    }
