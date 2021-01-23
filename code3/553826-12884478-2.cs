    public void CustomSort()
    {
        List<MyNode> nodes = new List<MyNode>();
        nodes.Add(new MyNode() { Id = 5, ParentId = 1, Title = "Anotherchild1" });
        nodes.Add(new MyNode() { Id = 6, ParentId = 3, Title = "Anotherchild2" });
        nodes.Add(new MyNode() { Id = 7, ParentId = 6, Title = "Anotherchild3" });
        nodes.Add(new MyNode() { Id = 1, ParentId = 0, Title = "Parent1" });
        nodes.Add(new MyNode() { Id = 2, ParentId = 1, Title = "Child1" });
        nodes.Add(new MyNode() { Id = 3, ParentId = 0, Title = "Parent2" });
        nodes.Add(new MyNode() { Id = 4, ParentId = 3, Title = "Child2" });
        Func<MyNode, List<int>> hierarchy = null;
        hierarchy = n =>
        {
            var n2 = nodes.FirstOrDefault(x => x.Id == n.ParentId);
            if (n2 != null) return hierarchy(n2).Concat(new List<int>() { n.Id }).ToList();
            return new List<int>() { n.ParentId,n.Id };
        };
        var debug = nodes.Select(x=>hierarchy(x)).ToList();
        var sortedList = nodes.OrderBy(n => String.Join(",", hierarchy(n).Select(x=>x.ToString("X8"))))
                              .ToList();
    }
    class MyNode
    {
        public int Id;
        public int ParentId;
        public string Title;
    }
---
    Id  PId Title              hierarchy (key to sort)
    1   0   Parent1             0 1
    2   1   Child1              0 1 2
    5   1   Anotherchild1       0 1 5
    3   0   Parent2             0 3
    4   3   Child2              0 3 4
    6   3   Anotherchild2       0 3 6
    7   6   Anotherchild3       0 3 6 7
