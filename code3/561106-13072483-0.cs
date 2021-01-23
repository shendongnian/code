        static void Main(string[] args)
        {     
            List<Group> groups = new List<Group>();               
            ...
            PrintTree(groups, "", null);
        }
        static void PrintTree(List<Group> allGroups, string lead, int? id)
        {
            var children = allGroups.Where(g => g.ParentID == id).ToList();
            if (children.Count > 0)
            {
                int n = children.Count-1;
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(lead + "├──" + children[i].Name);
                    PrintTree(allGroups, lead + "│  ", children[i].ID);                    
                }
                Console.WriteLine(lead + "└──" + children[n].Name);
                PrintTree(allGroups, lead + "   ", children[n].ID);                    
            }
        }
