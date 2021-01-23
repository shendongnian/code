    //I don't know your logic here, but probably there is a bug - you are modifying collection and then use old index position - you'll get unexpected results =). Let you fix it on your own, so just rewrite your code
    for (int i = 0; i <= lstEmployeelist.SelectedIndices.Count; i++ )
    {
        var index = lstEmployeelist.SelectedIndices[i]
        object item = _myPrivateCollection[index];
        
        _myPrivateCollection.Add(item);
        _myPrivateCollection.RemoveAt(index);
    }
    lstEmployeelist.DataSource = null;
    lstEmployeelist.DataSource = _myPrivateCollection;
