        ...
        ObservableCollection<ABC> Items { get;set}
        ListCollectionView ItemsView { get;set }
        ...
        // View filter logic
        ItemsView.Filter = o =>
                {
                    var abc = o as ABC;
                    if (abc == null) return false;
                    return abc.Category == "Alphabet" &&
                           abc == Items.First(i => i.Name == abc.Name);
                };
        
     
        
