{
            var child = new Child();
            // here is where I went wrong before -- I used typeof(Child), with no known types to serialize
            var serializer = new DataContractSerializer(typeof(Parent), new Type[] { typeof(Child) });
            var stream = new MemoryStream();
            serializer.WriteObject(stream, child);
            stream.Position = 0;
            serializer = new DataContractSerializer(typeof(Parent), new Type[] { typeof(Child) });
            object test = serializer.ReadObject(stream);
            stream.Dispose();
            Console.WriteLine(test.ToString());
            Console.ReadLine();
}
