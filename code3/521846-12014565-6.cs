    public static class Serializer
    {
        // returns false in case of an error
        public static bool save(string fileName, Object obj)
        {
        	XmlSerializer serializer = null;
        	TextWriter textWriter = null;
        	bool res = false;
            try
            {
				serializer = new XmlSerializer(obj.GetType());
				textWriter = new StreamWriter(fileName);
				serializer.Serialize(textWriter,obj);
            	res = true;
            }
            catch(Exception ex)
            {
                // handle error
            }
            finally
            {
                if (null != textWriter)
					textWriter.Close();
            }
			return res;
        }
        // returns null in case of an error
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
                // handle error
            }
            finally
            {
                if (null != textReader)
					textReader.Close();
            }
            return res;
        }
    }
