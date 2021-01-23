        public byte[] ObjectToByteArray(Object obj)
        {
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, obj);
            byte[] rval = fs.ToArray();
            fs.Close();
            return rval;
        }
        public object ByteArrayToObject(Byte[] Buffer)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(Buffer);
            object rval = formatter.Deserialize(stream);
            stream.Close();
            return rval;
        }
