    YourTreeViewControl.Nodes.Add("C:\Temp")
    Recursive(@"C:\Temp", Tree.Nodes(0))
        void Recursive(string d, TreeNode nodePar)
        {
            DirectoryInfo dir = new DirectoryInfo(d);
            foreach (var item in dir.GetDirectories()) {
                Recursive(item.FullName, nodePar.Nodes.Add(item.Name));
            }
        }
