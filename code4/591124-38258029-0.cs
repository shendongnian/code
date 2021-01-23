        private void listView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var listView = sender as ListView;
            if (listView != null)
            {
                for (var i = 0; i < listView.CheckedItems.Count; i++)
                {
                    listView.CheckedItems[i].Checked = false;
                }
            }
        }
