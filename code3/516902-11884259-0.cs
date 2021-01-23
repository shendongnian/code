        public delegate T Async<T>(string xml);
        public void Start<T>()
        {
            string xml = "<Person/>";
            Async<T> asyncDeserialization = DeserializeObject<T>;
            asyncDeserialization.BeginInvoke(xml, Callback<T>, asyncDeserialization);
        }
        private void Callback<T>(IAsyncResult ar)
        {
            Async<T> dlg = (Async<T>)ar.AsyncState;
            T item = dlg.EndInvoke(ar);
        }
        
        public T DeserializeObject<T>(string xml)
        {
            using (StringReader reader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(reader))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    T theObject = (T)serializer.ReadObject(xmlReader);
                    return theObject;
                }
            }
        }
