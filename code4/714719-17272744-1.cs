    private void imageListView_Clicked(object sender, EventArgs e)
       {
            String img;
            int i=0;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (item.Selected)
                    img = item.ImageList.Images[i].PropertyItems.ToString();
                i++;
            }
       }
