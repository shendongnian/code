    var unorderedList = new List<ToolStripItem>();
    for (int i = 0; i < toolStripDropDownButton1.DropDownItems.Count;i++ )
    {
        unorderedList.Add(toolStripDropDownButton1.DropDownItems[i]);
    }
    var orderedList = unorderedList.OrderBy(l => l.Text).ToList();
    toolStripDropDownButton2.DropDownItems.AddRange(orderedList.ToArray());
