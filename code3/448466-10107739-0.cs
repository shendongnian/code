    private void PrintGroups(IEnumerable<IGrouping<int, int>> groups)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var group in groups)
        {
            builder.AppendFormat("Group {0}: {1}\r\n", group.Key, group.Count());
        }
        txt1.Text = builder.ToString();
    }
