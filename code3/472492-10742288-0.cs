    public static class Background
    {
        public static string Get()
        {
            photoBlogModelDataContext _db = new photoBlogModelDataContext();
            var image = _db.Images.ToList().OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            return image.Small; // Always same value?
        }
    }
