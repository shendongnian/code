    public partial class DanubeDataSet 
    {
        partial class ProductsRow
        {
            public decimal TotalCost
            {
                get
                {
                    return Quantity * Price;
                }
            }
        }
    }
