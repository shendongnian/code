           int max = trees.Count;
            for (int i = 0; i < max; i++)
            {
                QuadTree tree = trees[i];
                if (tree.Children.Count != 0)
                {
                    foreach(QuadTree child in tree.Children)
                    {
                        trees.Add(child);
                    }
                }
                max = trees.Count;
            }
