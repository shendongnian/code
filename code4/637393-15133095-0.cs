    public class MyViewModel
    {
        public BookModel1 Book { get; set; }
        public int? SelectedCategoryId { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
