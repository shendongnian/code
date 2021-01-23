        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in chkList1.SelectedItems)
            {
                if (!lstBox1.Items.Contains(item))
                    lstBox1.Items.Add(item);
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (var item in lstBox1.SelectedItems)
            {
                lstBox1.Items.Remove(item);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstBox1.Items.Clear();
            //if you want to hide the lstBox you'll write
            //lstBox1.Visible = true;
        }
