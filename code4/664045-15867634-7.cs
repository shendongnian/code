    static List<Group> BuildTree(IEnumerable<Group> items)
    {
        List<Group> itemL = items.ToList();
        itemL.ForEach(i => i.Children = items.Where(ch => ch.ParentID == i.ID).ToList());
        return itemL.Where(i => i.ParentID == null).ToList();
    }
