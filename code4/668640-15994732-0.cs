        public class ObjectXmlSerializer
        {
            //---------------------------------------------------------------------
            public override Byte[] Serialize(Object obj)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    new XmlSerializer(obj.GetType()).Serialize(ms, obj);
                    return ms.ToArray();
                }
            }
            //---------------------------------------------------------------------
            public override T Deserialize<T>(Byte[] bObj)
            {
                using (MemoryStream ms = new MemoryStream(bObj))
                {
                    return (T)new XmlSerializer(typeof(T)).Deserialize(ms);
                }
            }
            //---------------------------------------------------------------------
            public override T Deserialize<T>(Stream iostream)
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(iostream);
            }
        }
