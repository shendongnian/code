        [Serializable]
        class CustomClass
        {
            int _id;
            string _value;
            public CustomClass(int id, string value)
            {
                _id = id;
                _value = value;
            }
        }
        [Serializable]
        class CustomClassCollection
        {
            private IList<CustomClass> _list = null;
            public CustomClassCollection()
            {
                _list = new List<CustomClass>();
            }
            public void Add(CustomClass a)
            {
                _list.Add(a);
            }
        }
        public static class ObjectCopier
        {
            public static T Clone<T>(this T source)
            {
                if (!typeof(T).IsSerializable)
                {
                    throw new ArgumentException("The type must be serializable.", "source");
                }
                if (Object.ReferenceEquals(source, null))
                {
                    return default(T);
                }
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new MemoryStream();
                using (stream)
                {
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
            }
        }
