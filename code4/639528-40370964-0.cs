    private void cb_magia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maxNumber = 4;
            int iSelectedIndex = cb_magia.SelectedIndex;
            if (cb_magia.CheckedItems.Count > maxNumber)
            {
               cb_magia.SetItemCheckState(iSelectedIndex, CheckState.Unchecked);
               MessageBox.Show("you had checked the maximum checkbox value allowed");
            }
        }
