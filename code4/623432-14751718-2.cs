    public class PrimaryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SecondaryItem> SecondaryItems { get; set; }
        private SecondaryItem _selectedSecondaryItem;
        public SecondaryItem SelectedSecondaryItem
        {
            get { return _selectedSecondaryItem; }
            set
            {
                _selectedSecondaryItem = value;
                
                if (_selectedSecondaryItem != null)
                { // My breakpoint here
                    //TO DO
                }
            }
        }
    }
    public class SecondaryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
