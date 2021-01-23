        var treeViewItemNames = new[] { "Continent", "Country", "Province", "Territory" };
         var topItems = new List<TreeViewContinents>();
         foreach (var continent in continentsList)
         {
             List<TreeViewContinents> currentLevel = topItems;
             TreeViewContinents parentItem = null;
             foreach (var sectionTitle in treeViewItemNames)
             {
                 String value = Convert.ToString(continent[sectionTitle]);
                 TreeViewContinents currentItem = currentLevel.FirstOrDefault(tree => tree.Content == value);
                 if (currentItem == null)
                 {
                     currentItem = new TreeViewContinents { Name = sectionTitle, Content = value };
                     currentItem.Children = new List<TreeViewContinents>();
                     if (parentItem != null)
                     {
                         currentItem.Parent = parentItem;
                     }
                     currentLevel.Add(currentItem);
                 }
                 parentItem = currentItem;
                 currentLevel = currentItem.Children;
             }
         }
