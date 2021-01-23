    [ServiceContract]
    public class DocumentService
    {
        [OperationContract]
        [WebTemplate("{name}"]
        public Document Create(Stream stream, string name)
        {
            var id = Guid.NewGuid().ToString("N");
            using(FileStream outputStream = File.Create(Path.Combine("c:\\temp\\", id)))
            {
                stream.CopyTo(outputStream);
            }
            Document document = new Document(); 
            document.Name = name;
            document.Id = id;
            // Save document to database
            // Set headers 
            return document;
        }
    }
