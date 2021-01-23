    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    
    class Test
    {
        static void Main()
        {
            using (Stream stream = File.OpenRead("test.json"))
            {
                var serializer = new DataContractJsonSerializer(typeof(Library));
                Library library = (Library) serializer.ReadObject(stream);
                Console.WriteLine(library.Books[0].Name);
            }
            
        }
    }
    
    [DataContract]
    class Book
    {
        [DataMember(Name="name")] public string Name { get; set; }
        [DataMember(Name="orig")] public string Orig { get; set; }
        [DataMember(Name="date")] public string Date { get; set; }
        [DataMember(Name="lang")] public string Lang { get; set; }
    }
    
    [DataContract]
    class Library
    {
        [DataMember(Name="books")] public IList<Book> Books { get; set; }
        [DataMember(Name="src")] public string Src { get; set; }
        [DataMember(Name="id")] public string Id { get; set; }
    }
