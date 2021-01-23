        List<String> itemList = new List<string>();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.Cells[0].Value = null)
            {
                itemList.Add(row.Cells[0].Value.ToString());
            }
        }
        itemList.Sort();
        string[] SortedArray = itemList.ToArray();
        for (int j = 0; j < SortedArray.Length; j++)
        {
            MessageBox.Show(SortedArray[j]);
        }
