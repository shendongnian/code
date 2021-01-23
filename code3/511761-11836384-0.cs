    .BindTo(Model,(NavigationBindingFactory<TreeViewItem> mappings) =>
        {
            mappings.For<Category>(binding => binding
                    .ItemDataBound((item, category) =>
                    {
                        item.Action("Test", "Home", new{text=category.CategoryName});//here you can assign the action method , the last parameter is the route values
                        item.Text = category.CategoryName;
                    })
         }
