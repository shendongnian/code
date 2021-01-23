     public class MyProduct
        {   
            public int ProductId { get; set; }
            public string Title { get; set; }
            public virtual ICollection<Category> CategoryList { get; set; }
        }
