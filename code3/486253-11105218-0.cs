        [Table("Products")]
        public class Product
        {
            public Int64 ProductID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int CategoryID { get; set; }
            public virtual Category Category { get; set; }
        }
