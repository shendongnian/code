     List<String> arr = new List<string>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            arr.Add(txtItem.Text);
            lstItem.DataSource = arr.ToArray();
            txtItem.Focus();
        }
    //When i delete
        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            foreach (string item in lstItem.SelectedItems)
            {
                arr.Remove(item);
            }
            lstItem.DataSource = arr.ToArray();
            
         }
