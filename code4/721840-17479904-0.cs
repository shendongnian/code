    public decimal SalesPrice(Customer customer)
    {
        return prices[customer.PriceListNumber - 1];
    }
 
