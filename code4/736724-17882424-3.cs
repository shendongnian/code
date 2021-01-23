        public Program()
        {
            List<TreeViewItem> items = new List<TreeViewItem>()
            {
                new TreeViewItem(){
                    Text="Hi", 
                    Items=new List<TreeViewItem>()
                    {
                         new TreeViewItem(){  Text="Hi/1" },
                         new TreeViewItem(){  Text="Hi/2" },
                         new TreeViewItem(){  Text="Hi/3" }
                    }
                },
                new TreeViewItem(){
                    Text="Hm", 
                    Items=new List<TreeViewItem>()
                    {
                         new TreeViewItem(){  Text="Hm/1" },
                         new TreeViewItem(){  Text="Hm/2" },
                         new TreeViewItem(){  Text="Hm/3" }
                    }
                }
            };
            Console.WriteLine("Before");
            PrintNode(items);
            List<TreeViewItem> toDelete = new List<TreeViewItem>()
            {
                items[0].Items[1],
                items[1].Items[2]
            };
            Console.WriteLine("\nTo Delete");
            foreach (TreeViewItem item in toDelete)
            {
                Console.WriteLine(item.Text);
            }
            RemoveChildNode(items, toDelete);
            Console.WriteLine("\nRemoved");
            PrintNode(items);
            Console.ReadKey();
        }
        public void RemoveChildNode(List<TreeViewItem> items, List<TreeViewItem> toDelete)
        {
            if (toDelete.Count == 0)
                return;
            if (items.Count == 0)
                return;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                TreeViewItem item = items[i];
                int indexOf = toDelete.IndexOf(item);
                if (indexOf == -1)
                {
                    RemoveChildNode(item.Items, toDelete);
                }
                else
                {
                    toDelete.RemoveAt(indexOf);
                    items.RemoveAt(i);
                }
            }
        }
        public void PrintNode(List<TreeViewItem> item, string indent = "")
        {
            foreach (TreeViewItem node in item)
            {
                Console.Write(indent);
                Console.WriteLine(node.Text);
                PrintNode(node.Items, indent + "  ");
            }
        }
