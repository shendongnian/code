    public class Config
    {
        private readonly Settings _settings;
        private readonly ACollectionOfStrings _selectedCategories;
        internal Config(Settings settings)
        {
            _settings = settings;
            if(_settings.SelectedCategories == null)
                _settings.SelectedCategories = new StringCollection();
            _selectedCategories = new ACollectionOfStrings(_settings.SelectedCategories);
        }
        public IEnumerable<string> SelectedCategories
        {
            get { return _selectedCategories; }
        }
        private void ModifySettings(Action<Settings> modification)
        {
            modification(_settings);
            Save();
        }
        private void Save()
        {
            _settings.Save();
        }
        public void AddCategory(string category)
        {
            _selectedCategories.Add(category);
            SaveList();
        }
        private void SaveList()
        {
            ModifySettings(s => s.SelectedCategories = _selectedCategories.List);
        }
        public void Remove(string category)
        {
            _selectedCategories.Remove(category);
            SaveList();
        }
    }
