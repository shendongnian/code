        List<MediaItem> mediaItemList = new List<MediaItem>();
        mediaItemList.Add(new MediaItem("Group: Hear It", "item: The Smiths"));
        mediaItemList.Add(new MediaItem("Group: Hear It", "item: Fernando Sor"));
        mediaItemList.Add(new MediaItem("Group: See It", "item: Longmire"));
        mediaItemList.Add(new MediaItem("Group: See It", "item: Ricky Gervais Show"));
        mediaItemList.Add(new MediaItem("Group: See It", "item: In Bruges"));
        var results = from item in mediaItemList.AsEnumerable()
                      where item.Action == "Group: Hear It"
                      select item.Name;
        foreach (string name in results) {
            MessageBox.Show(name);
        }
