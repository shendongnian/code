        virtualList.RetrieveVirtualItem += (s, e) =>
        {
            e.Item = new ListViewItem();
            e.Item.Text = "Item " + e.ItemIndex.ToString();
            e.Item.ImageIndex = imagelist.Images.IndexOfKey("key");
        };
