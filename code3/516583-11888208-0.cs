    Stream Read = null;
    object m_Configuration = null;
    try
    {
         FileInfo FI = new FileInfo("C:\\");
               
         Read = FI.OpenRead();
         XmlSerializer serializer = new XmlSerializer(typeof(CommandCollection));
                
         m_Configuration = serializer.Deserialize(Read);
    }
    finally
    {
         if (Read != null)
         {
               Read.Close();
         }
    }
