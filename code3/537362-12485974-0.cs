    private void btnGO_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chBoxListTables.Items.Count; i++)
        {
              if (chBoxListTables.GetItemChecked(i))
            {
                string str = (string)chBoxListTables.Items[i];
                MessageBox.Show(str);
            }
        }
    }
