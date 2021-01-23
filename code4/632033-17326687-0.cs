    private ColumnHeader GetColumn(string Text)
    {
        for (int i = 0; i < listView1.Columns.Count; i++)
            for (int j = 0; j < listView1.Items.Count; j++)
                if (listView1.Items[j].SubItems.Count - 1 >= i)
                    if (listView1.Items[j].SubItems[i].Text == Text)
                        return listView1.Columns[i];
        return null;
    }
