    var lst = labels.OrderBy(x => int.Parse(x.Name.Substring("label".Length))).ToList();
    for (int i = 0; i < lst.Count - 1; i++)
    {
        MessageBox.Show(lst[i].Name);
        ...
