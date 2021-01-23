    public ProductMap : ClassMap<Product>
    {  
      public ProductMap()  
      {  
        Id(Reveal.Member<Product>("Id"));  
      }  
    }
