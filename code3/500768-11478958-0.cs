        public AdminViewModel(UserControl view) {
            this.view = view;
            var designMode = DesignerProperties.GetIsInDesignMode(view);
            if (designMode) {
                Items = new ObservableCollection<ItemModel>
                          {new ItemModel {Name = "Item1"}, 
                           new ItemModel {Name = "Item2"}};
            }
            else {
                Items= new ObservableCollection<ItemModel>(Gateway.GetItems());
            }   
        }
