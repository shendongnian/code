    if (e.KeyCode == Keys.Delete)
    {
      foreach (int index in listBox1.SelectedIndices.Cast<int>().OrderByDescending(i=>i))
      {
        root.Elements("Entry").ElementAt(index).Remove();
        listBox1.Items.RemoveAt(index);
      }
    
      root.Save(path);
    }
