    public List<IProduct> myOriginalProductList;
    ...
    public void YourMethod()
    {
    	List<IProduct> otherProductList = new List<IProduct>();
    	Parallel.ForEach(myOriginalProductList, product =>
    		{
    		   //Some code here removed for brevity
    			lock (otherProductList)
    			{
    				otherProductList.Add((IProduct)product.Clone());
    			}
    		});
    }
