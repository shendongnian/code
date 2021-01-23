            List<String> itemList = new List<String>();
            // Generate some items to add to the list.
            for (int i = 1; i <= 33; i++)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder("Item ");
                sb.Append(i.ToString());
                itemList.Add(sb.ToString());
            }
            **//add at given index**
             itemList.Insert(10, "Extra item");
            // Wrap the itemList in a PagedCollectionView for paging functionality
            PagedCollectionView itemListView = new PagedCollectionView(itemList);
