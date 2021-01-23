    public class MyViewModel : ViewModelBase
    {
        private List<PrimaryItem> _primaryItems;
        public List<PrimaryItem> PrimaryItems
        {
            get { return _primaryItems; }
            set { _primaryItems = value; RaisePropertyChanged("PrimaryItems"); }
        }
        public ErrorMessageViewModel()
        {
            this.PrimaryItems = new List<PrimaryItem>
                {
                    new PrimaryItem
                        {
                            SecondaryItems =
                                new List<SecondaryItem>
                                    {
                                        new SecondaryItem { Id = 1, Name = "First" },
                                        new SecondaryItem { Id = 2, Name = "Second" },
                                        new SecondaryItem { Id = 3, Name = "Third" }
                                    },
                            Name = "FirstPrimary",
                            Id = 1
                        }
                };
        }
    }
