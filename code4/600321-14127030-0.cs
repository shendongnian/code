        for (int i = 0; i < 5; i++)
        {
            foreach (int index in listView1.SelectedIndices)
            {
                listView1.Items[index].Selected = false;
            }
            listView1.Items.Add(i.ToString());
            listView1.Items[listView1.Items.Count - 1].Selected = true;
        }
