    [XmlArray("Products")]
    public List<Product> Get()
    {
        return repository.GetProducts();
    }
