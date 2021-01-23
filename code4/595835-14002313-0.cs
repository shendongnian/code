    public class BaseModel
    {
        public string UserLanguage { get; set; }
        ...
    }
    
    public class SomePageModel : BaseModel
    {
        public int Id { get; set; }
        public PagedList<Whatever> PagedStuff { get; set; }
        ...
    }
