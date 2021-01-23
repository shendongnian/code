    public class MyData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
    
    public IEnumerable<MyData> GetMyDataFromDocuments()
    {
        return context.Documents.Select(d => new MyData
            {
                Id = d.Id,
                UserId = d.UserId
            });
    }
