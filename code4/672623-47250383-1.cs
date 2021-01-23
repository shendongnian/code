    public class UniqueFileName : ValidationAttribute
    {
        private readonly NewsService _newsService = new NewsService();
        public override bool IsValid(object value)
        {
            if (value == null) { return false; }
            var file = (HttpPostedFile) value;
            return _newsService.IsFileNameUnique(file.FileName);
        }
    }
