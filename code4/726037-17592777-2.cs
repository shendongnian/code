    [Serializable()]
    public class clsSchnappschuss<T>
    {
        private MemoryStream mvArbeitspeicherZugriff;
        private BinaryFormatter mvFormatierer;
        public clsSchnappschuss()
        {
            if (Attribute.GetCustomAttribute(typeof(T), typeof(SerializableAttribute)) == null)
            {
                Trace.WriteLine(string.Concat(typeof(T).FullName, 
                                              " ist nicht serialisiebar!"));
                throw new InvalidOperationException(string.Concat(string.Format("{0} ist nicht serialisierbar.",
                                                                                typeof(T).FullName),
                                                                                " Die Klasse muss das Attribut ",
                                                                                "Serializable einbinden ",
                                                                                "[Serializable()] ",
                                                                                "um clsSchnappschuss verwenden zu ",
                                                                                "können."));
            }
            mvFormatierer = new BinaryFormatter();
        }
        public clsSchnappschuss<T> BxSpeichern(T obj)
        {
            mvArbeitspeicherZugriff = new MemoryStream();
            mvFormatierer.Serialize(mvArbeitspeicherZugriff, obj);
            return this;
        }
        public T BxWiederherstellen()
        {
            mvArbeitspeicherZugriff.Seek(0, SeekOrigin.Begin);
            mvFormatierer.Binder = new clsCustomBinder();
            T obj = (T)mvFormatierer.Deserialize(mvArbeitspeicherZugriff);
            mvArbeitspeicherZugriff.Close();
            return obj;
        }
    }
