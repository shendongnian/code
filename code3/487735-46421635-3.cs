        SelectedItemsContainer selectionContainer = new SelectedItemsContainer();
        public SelectedItemsContainer SelectionContainer
        {
            get { return this.selectionContainer; }
            set
            {
                if (this.selectionContainer != value)
                {
                    this.selectionContainer = value;
                    this.OnPropertyChanged("SelectionContainer");
                }
            }
        }
