    foreach (var item in this.datasetItemset
        .Select(transaction => transaction.Split(new char[] { ' ' }))
        .SelectMany(items => items
            .Where(item => !itemList.Contains(item))))
        {
            itemList.Add(item);
            itemsetScanning.Add(item, 0);
        }
