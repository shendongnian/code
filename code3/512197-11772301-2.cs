    //Flatten the groups into a KeyValuePair<string, Contacts> list using LINQ.
    var flatGroups 
        = listGroups.SelectMany(
            ctc => ctc.Groups.Select(
                 grp => new KeyValuePair<string, Contact>(grp, ctc))).ToList();          
    //Apply CollectionViewSource group on the `Key`.
    var collectionVwSrc = new CollectionViewSource();
    collectionVwSrc.Source = flatGroups;
    collectionVwSrc.GroupDescriptions.Add(new PropertyGroupDescription("Key"));
    //Apply groups as itemssource to the TreeView.
    MyGroupsTree.ItemsSource = collectionVwSrc.View.Groups; 
