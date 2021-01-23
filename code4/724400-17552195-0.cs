    for (int i = 0; i < list.Count; i++)
    {
        Settings.Default["Item" + i.ToString()] = listBox1.GetSelected(i);
    }
    Properties.Settings.Default.Save();
