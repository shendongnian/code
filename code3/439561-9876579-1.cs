        public class Product
        {
            // EF will automatically assume FooId is the foreign key for Foo
            [Required]
            public int CategoryId { get; set; }
            public virtual Category Category { get; set; }
        }
