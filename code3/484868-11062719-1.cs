    public class CategoryList
    {
        public ObservableCollection<ComboBoxSampleItemViewModel> Categories { get; set; }
        public ComboBoxSampleItemViewModel Selected { get; set; }
        public CategoryList()
        {
            Categories = new ObservableCollection<ComboBoxSampleItemViewModel>();
            var cat1 = new ComboBoxSampleItemViewModel() { Name = "Categorie 1" };
            var cat2 = new ComboBoxSampleItemViewModel() { Name = "Categorie 2" };
            var cat3 = new ComboBoxSampleItemViewModel() { Name = "Categorie 3" };
            var cat4 = new ComboBoxSampleItemViewModel() { Name = "Categorie 4" };
            Categories.Add(cat1);
            Categories.Add(cat2);
            Categories.Add(cat3);
            Categories.Add(cat4);
            this.Selected = cat3;
        }
        internal ComboBoxSampleItemViewModel FindByName(string p)
        {
            return this.Categories.Where(s => s.Name.Equals(p)).FirstOrDefault();
        }
    }
