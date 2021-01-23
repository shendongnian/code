    [Serializable]
    public class YourModel
    {
        private int _mid
        {
            get { Categories.Count / 2; }
        }
        private int _top
        {
            get { Categories.Count - _mid; }
        }
        public List<Category> CategoriesLowerHalf
        {
            get { Categories.OrderBy(i => i.CategoryName).Take(_mid); }
        }
        public List<Category> CategoriesUpperHalf
        {
            get { Categories.OrderBy(i => i.CategoryName).GetRange(_mid, _top); }
        }
        // rest of your model
    }
