    [XmlArray("Products")]
    public List<Product> Products
    {
        get { return repository.GetProducts(); }
    }
