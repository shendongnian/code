        public static Node TreeFromArray(Item[] arr)
        {
            var tree = new Node();
            
            var parents = new Node[arr.Length];
            parents[0] = tree;
            foreach (var item in arr)
            {
                var curr = parents[item.Depth + 1] = new Node {Name = item.Name};
                parents[item.Depth].Childs.Add(curr);
            }
            return tree;
        }
