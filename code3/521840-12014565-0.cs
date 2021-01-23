    public static class Serializer
    {
        public static void save(string fileName, Object obj)
        {
        	XmlSerializer serializer = null;
        	TextWriter textWriter = null;
            try
            {
				serializer = new XmlSerializer(obj.GetType());
				textWriter = new StreamWriter(fileName);
				serializer.Serialize(textWriter,obj);
            }
            catch
            {
                // do nothing, just ignore any possible errors
            }
            finally
            {
                if (null != textWriter)
					textWriter.Close();
            }
        }
        public static Object load(Type type, string fileName)
        {
            XmlSerializer deserializer=null;
        	TextReader textReader=null;
            Object res = null;
            try
            {
				deserializer = new XmlSerializer(type);
				textReader = new StreamReader(fileName);
				res=deserializer.Deserialize(textReader);
            }
            catch(Exception ex)
            {
                // do nothing, just ignore any possible errors
            }
            finally
            {
                if (null != textReader)
					textReader.Close();
            }
            return res;
        }
    }
