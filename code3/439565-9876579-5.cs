        public class Product
        {
            // EF will automatically assume FooId is the foreign key for Foo.
            // When mapping input, change this one, not the associated object.
            [Required]
            public int CategoryId { get; set; }
            public virtual Category Category { get; set; }
        }
