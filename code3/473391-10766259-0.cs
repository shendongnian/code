    static void Main()
    {
        var ser = SerializerCache<Foo>.Instance;
        var list = new EntityListBase<Foo> {
            Items = new List<Foo> {
                new Foo { Bar = "abc" }
        } };
        ser.Serialize(Console.Out, list);
    }
    static class SerializerCache<T> where T : EntityBase, new()
    {
        public static XmlSerializer Instance;
        static SerializerCache()
        {
            var xao = new XmlAttributeOverrides();
            xao.Add(typeof(EntityListBase<T>), new XmlAttributes
            {
                XmlRoot = new XmlRootAttribute(typeof(T).Name + "List")
            });
            xao.Add(typeof(EntityListBase<T>), "Items", new XmlAttributes
            {
                XmlElements = { new XmlElementAttribute(typeof(T).Name) }
            });
            Instance = new XmlSerializer(typeof(EntityListBase<T>), xao);
        }
    }
