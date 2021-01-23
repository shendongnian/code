     public class ViewModel :INotifyPropertyChanged
            {
                private ObservableCollection<Category> _categories = new ObservableCollection<Category>();
                private Category _currentCategory;
        
                public ObservableCollection<Category> Categories
                {
                    get { return _categories; }
                    set { _categories = value; OnPropertyChanged("Categories");}
                }
        
                public Category CurrentCategory
                {
                    get { return _currentCategory; }
                    set { _currentCategory = value; OnPropertyChanged("CurrentCategory");}
                }
        
                public ICollectionView CategoriesView { get; private set; }
        
                public ViewModel()
                {
                    Categories.Add(new Category{Id = Guid.NewGuid(), Name = "Cat1"});
                    Categories.Add(new Category{Id = Guid.NewGuid(), Name = "Cat2"});
                    Categories.Add(new Category{Id = Guid.NewGuid(), Name = "Cat3"});
        
                    CategoriesView = CollectionViewSource.GetDefaultView(Categories);
                    CategoriesView.CurrentChanged += OnCategoriesChanged;
                    CategoriesView.MoveCurrentToFirst();
                }
        
                private void OnCategoriesChanged(object sender, EventArgs e)
                {
                    var selectedCategory = CategoriesView.CurrentItem as Category;
                    if (selectedCategory == null) return;
        
                    CurrentCategory = selectedCategory;
                }
        
                public event PropertyChangedEventHandler PropertyChanged;
        
                protected virtual void OnPropertyChanged(string propertyName)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        
            public class Category
            {
                public Guid Id { get; set; }
        
                public string Name { get; set; }
            }
