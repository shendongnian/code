    private void lb_itemList_SelectedIndexChanged(object sender, EventArgs e)
    {
            if (lb_itemList.SelectedIndex > -1)
            {
                  var item = lb_itemList.SelectedItem as Item;
                  if (item != null)
                  {
                        lblDescription.Text = item.Description;
                  }
            }
    }
