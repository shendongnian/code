     internal void ButtonPushed() {
            SelectedObject = ItemSource.First(x => x.Description == "5");
            Filters.Add("1");
            Filters.Add("5");
            CollectionView.Refresh();
            ValidateSelectedDataObject();
        }
        public void ValidateSelectedDataObject() {
            DataObject currentSelectedItem = this.SelectedObject;
            this.SelectedObject = null;
            foreach (DataObject item in CollectionView) {
                
                if (item.Id == currentSelectedItem.Id) {
                    this.SelectedObject = currentSelectedItem;
                }
            }
        }
