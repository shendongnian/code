        public ObservableList<String> Strings { get; set; }
        public MyViewModel()
        {
            this.Strings = new ObservableList<string>();
            this.Strings.AddRange(new[] { "1", "2", "3", "4" });
        }
