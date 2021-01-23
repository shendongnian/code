            Categories = query.ToList<Category>();
            foreach (Category c in Categories)
            {
                TreeViewItem TVP = new TreeViewItem() { Header = c.CategoryName.ToString() };
                var query2 = from xx in ctx.RecipeCategories.Where(o => o.CategoryId == c.CategoryId) select xx;
                foreach (var rc in query2)
                {
                    TreeViewItem TVC = new TreeViewItem() { Header = rc.Recipe.RecipeName.ToString() };
                    TVP.Items.Add(TVC);
                    
                }
                tvwRecipe.Items.Add(TVP);
            }
