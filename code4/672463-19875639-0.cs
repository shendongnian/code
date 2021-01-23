    public IEnumerable<Product> AsCombo(Product p)
    {
        //if not equal, return both
        if (!Equals(p))
        {
            yield return this;
            yield return p;
            yield break;
        }
    
        //if equal return the one desired by checking all properties
        yield return new Product //always better to return new instance for linq queries
        { 
            Name = Name, 
            Code = Code, 
            Code1 = Code1 ?? p.Code1, //I give preference to 'this'
            Code2 = Code2 ?? p.Code2  //I give preference to 'this'
        };
    }
