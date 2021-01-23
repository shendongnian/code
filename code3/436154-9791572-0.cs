    /// <summary>
    /// A sales person
    /// </summary>
    public class SalesPerson
    {
        /// <summary>
        /// Gets or sets an array of products
        /// </summary>
        public Product[] Products { get; set; }
    
        /// <summary>
        /// Constructs a new sales person class, constructing a new products array
        /// </summary>
        public SalesPerson()
        {
            this.Products = new Product[5];
        }
    }
    
    /// <summary>
    /// A product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the sales amount array
        /// </summary>
        public int[] SalesAmount { get; set; }
    
        /// <summary>
        /// Constructs a new product, constructing a new sales amount array
        /// </summary>
        public Product()
        {
            this.SalesAmount = new int[31];
        }
    
        /// <summary>
        /// Gets the total sold
        /// </summary>
        public int GetTotalSold()
        {
            return this.SalesAmount.Sum();
        }
    }
