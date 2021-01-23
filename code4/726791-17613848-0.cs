            ListCollectionView EntityView = new ListCollectionView(new List<ProductShipment>);
            foreach (var entity in entitylist)
            {
                EntityView.AddNewItem(entity);
            }
            EntityView.CommitNew();
            OnPropertyChanged("EntityView");
