    List<List<GroupItem>> resultList = ...
    var roots = new List<GroupItem>();
    ICollection<GroupItem> parentLevel = roots;
    foreach (var nodeLevel in resultList.AsEnumerable().Reverse())
    {
        //Find each parent's child nodes:
        foreach (var parent in parentLevel)
        {
            parent.Items = nodeLevel.Where(node => node.ParentCode == parent.ItemCode)
                                    .Cast<SelectableItem>().ToList();
        }
        //Add parentless nodes to the root:
        roots.AddRange(nodeLevel.Where(node => node.ParentCode == null));
        //Prepare to move to the next level:
        parentLevel = nodeLevel;
    }
