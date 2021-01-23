    public class Tag
    {
        public int TagId { get; set; }
        public virtual List<Product> Products { get; set; }         /* 1 */
        public virtual List<ProductTag> ProductTags { get; set; }   /* 2 */
    }
    public class Product
    {
        public int ProductId { get; set; }
        public virtual List<Tag> Tags { get; set; }                 /* 1 */
    }
    public class ProductTag
    {
        public int ProductTagId { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public virtual Product Product { get; set; }                /* 3 */
        public virtual Tag Tag { get; set; }                        /* 2 */
    }
