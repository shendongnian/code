        protected void Page_Load(object sender, EventArgs e) {
            
            // The topmost category
            var top = new Category() {
                CategoryId = 1,
                CategoryName = "Top category"
            };
            // Prepare children for them
            var children = new List<Category>();
            // assign the children
            top.Children = children;
            // Populate the child list
            children.Add(new Category {
                CategoryId = 2,
                CategoryName = "First child",
                Parent = top
            });
            children.Add(new Category {
                CategoryId = 3,
                CategoryName = "Second child",
                Parent = top
            });
            //Add another sub child
            var thirdLevel = new List<Category>();
            thirdLevel.Add(new Category { 
                CategoryId = 4,
                CategoryName = "Sub sub category",
                Parent = children[0]
            });
            // assign it to the first child
            children[0].Children = thirdLevel;
            // Make up a new tree
            var tree = new CategoryTree(new[] { top });
            //Bind the source.
            TreeView1.DataSource = tree;
            // Bind it and enjoy.
            TreeView1.DataBind();
        }
