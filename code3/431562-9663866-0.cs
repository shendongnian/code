    bool YesToAll = false;
    public void AddItems(ListView.SelectedListViewItemCollection selectedItems, ListView.ListViewItemCollection items,TransferType type,string destPath)
    {
            foreach(ListViewItem item in selectedItems)
            {
                if (items.ContainsKey(item.Name) && !YesToAll)
                {   
                    ListViewItem lvtemp=items.Find(item.Name)[0];
    if((lvTemp.SubItems[0].Text!= "[Folder]" && item.SubItem[0].Text!="[Folder]" ) or (lvTemp.SubItems[0].Text== item.SubItems[0].Text && lvTemp.SubItems[0].Text="[Folder]") )
    {
                    MyMessageBox msgbox = new MyMessageBox("Item is already exists .. Do you want to replace (" + item.Text + ") ?");
                    msgbox.ShowDialog();
                    if (msgbox.DialogResult == DialogResult.Yes)
                    {
                        Add(item, type, destPath);
                    }
                    else if (msgbox.DialogResult == DialogResult.OK)
                    {
                        YesToAll = true;
                        Add(item, type, destPath);
                    }
                    else if (msgbox.DialogResult == DialogResult.No)
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
    }
                }
                else
                {
                    Add(item, type, destPath);
                }
            }
            YesToAll = false;
        }
        private void Add(ListViewItem item,TransferType type,string path)
        {
            ListViewItem newItem = (ListViewItem)item.Clone();
            newItem.ImageIndex = imageList1.Images.Add(item.ImageList.Images[item.ImageIndex],Color.Transparent);
            newItem.SubItems.Add(type.ToString());
            newItem.SubItems.Add(path);
            newItem.Tag = type;
            listView1.Items.Add(newItem);
        }
