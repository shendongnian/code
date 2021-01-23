    public class ProductAttachment : Attachment
    {
        protected ProductAttachment() { }
        public ProductAttachment(Product parent)
        {
            Parent = parent;
        }
        public Product Parent { get; protected set; }
    }
