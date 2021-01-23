    List<string> pagesToKeep = new List<string>() {"Design", "Picture"};
    for (int i = tabControlMain.TabPages.Count - 1; i>=0; i--)
    {
        string curName = tabControlMain.TabPages[i].Name;
        if(!pagesToKeep.Contains(curName))
        {
            tabControlMain.TabPages.RemoveAt(i);
        }
    }
