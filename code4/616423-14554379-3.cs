      public class Category
      {
        public int Id { get; set; }
        public string CategoryName { get; set; }
      }
    
    
      List<Category> category = new List<Category>();
      category.Add(new Category { Id = 1, CategoryName = "test"  });
      category.Add(new Category { Id = 2, CategoryName = "let" });
      category.Add(new Category { Id = 3, CategoryName = "go" });
      checkedListBox1.DataSource = category;
      checkedListBox1.DisplayMember = "CategoryName";
      //checkedListBox1.ValueMember = "Id"; 
      //checkedListBox1.Items.AddRange(category.Select(c => c.CategoryName).ToArray());
