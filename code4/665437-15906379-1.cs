        static void Main(string[] args)
        {
            var documentholder = new DocumentHolder { Document = new Documents { Title = "Title 1", DatePublished = DateTime.Now, Sector = "A17", Country = new List<string> { "EN-US", "EN-GB" } } };
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DocumentHolder));
            var ms = new MemoryStream();
            serializer.WriteObject(ms, documentholder);
            var text = Encoding.UTF8.GetString(ms.ToArray());
        }
