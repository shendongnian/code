    How about transforming this in lambda?
            List<Item> listItem = new List<Item>();
            foreach (StackPanel sp in spPhotos.Children)
            {
                foreach(Item item in sp.Children)
                {
                    listItem.Add(item);
                }
                sp.Children.Clear();
            }
            spPhotos.Children.Clear();
