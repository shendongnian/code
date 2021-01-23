            var serializer = new XmlSerializer(typeof(MyClass));
            using (var writer = new StringWriter())
            {
                var myClass = new MyClass() {SubClass = new MySubClass() {Name = "Test", Phone = "1234"}};
                serializer.Serialize(writer, myClass);
                string xml = writer.ToString();
            }
