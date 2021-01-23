    public class ViewModel
    {
        public List<Group> Groups { get; set; }
    }
    public class Group
    {
        private bool _isChecked;
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    // react to value change if necessary   
                }
            }
        }
    }
