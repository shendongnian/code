        public static void Main()
        {
            String path = @"c:\here is your path";
            // Method A: Read all information into a Byte Stream
            Byte[] data = System.IO.File.ReadAllBytes(path);
            String[] lines = System.IO.File.ReadAllLines(path);
            // Method B: Use a stream to do essentially the same thing. (More powerful)
            // Using block essentially means 'close when we're done'. See 'using block' or 'IDisposable'.
            using (FileStream stream = File.OpenRead(path))
            using (StreamReader reader = new StreamReader(stream))
            {
                // This will read all the data as a single string
                String allData = reader.ReadToEnd();
            }
            String outputPath = @"C:\where I'm writing to";
            // Copy from one file-stream to another
            using (FileStream inputStream = File.OpenRead(path))
            using (FileStream outputStream = File.Create(outputPath))
            {
                inputStream.CopyTo(outputStream);
                // Again, this will close both streams when done.
            }
            // Copy to an in-memory stream
            using (FileStream inputStream = File.OpenRead(path))
            using (MemoryStream outputStream = new MemoryStream())
            {
                inputStream.CopyTo(outputStream);
                // Again, this will close both streams when done.
                // If you want to hold the data in memory, just don't wrap your 
                // memory stream in a using block.
            }
            // Use serialization to store data.
            var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            // We'll serialize a person to the memory stream.
            MemoryStream memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, new Person() { Name = "Sam", Age = 20 });
            // Now the person is stored in the memory stream (just as easy to write to disk using a 
            // file stream as well.
            // Now lets reset the stream to the beginning:
            memoryStream.Seek(0, SeekOrigin.Begin);
            // And deserialize the person
            Person deserializedPerson = (Person)serializer.Deserialize(memoryStream);
            Console.WriteLine(deserializedPerson.Name); // Should print Sam
        }
        // Mark Serializable stuff as serializable.
        // This means that C# will automatically format this to be put in a stream
        [Serializable]
        class Person
        {
            public String Name { get; set; }
            public Int32 Age { get; set; }
        }
