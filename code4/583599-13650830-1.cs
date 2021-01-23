        ObservableCollection<Group<PlacePoint>> searchResults = new ObservableCollection<Group<PlacePoint>>();
        public SearchPage()
        {
            InitializeComponent();
            longList.ItemsSource = this.searchResults;
        }
        async void doSearch()
        {
            List<Group<PlacePoint>> tempResults = await SearchHelper.Instance.getSearchResults(txtSearchTerm.Text);
            // Clear existing collection and re-add new results
            this.searchResults.Clear();
            foreach (Group<PlacePoint> grp in tempResults )
            {
                this.searchResults.Add(grp);
            }
        }
