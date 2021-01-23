    public class Image
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string AlternateText { get; set; }
        public int PersonId { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public List<Image> Images {
            get
            {
                return DbContext.Images.Where(image => image.PersonId == this.Id).ToList();
            }}
    }
