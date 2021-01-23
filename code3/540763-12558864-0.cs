    ComboBoxItemCollection itemsCollection = comboBoxEdit1.Properties.Items;
    itemsCollection.BeginUpdate();
    try {
        foreach (var item in list) 
            itemsCollection.Add(item);
    }
    finally {
        itemsCollection.EndUpdate();
    }
