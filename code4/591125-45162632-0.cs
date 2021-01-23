    private void LstFirstPageBanner_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var listView = sender as ListView;
            if (listView != null)
            {
                var checkedCount = listView.CheckedItems.Count;
                listView.ItemCheck -= LstFirstPageBanner_ItemCheck;
                for (var i = 0; i < checkedCount; i++)
                {
                    listView.CheckedItems[i].Checked = false;
                }
                listView.ItemCheck += LstFirstPageBanner_ItemCheck;
            }
        } 
