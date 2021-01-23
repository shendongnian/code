    // If Equals() returns true for a pair of objects 
    // then GetHashCode() must return the same value for these objects.
    public int GetHashCode(Product product)
    {
        //Check whether the object is null
        if (Object.ReferenceEquals(product, null)) return 0;
        //Get hash code for the Name field if it is not null.
        int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();
        //Get hash code for the Code field.
        int hashProductCode = product.Code.GetHashCode();
        //Calculate the hash code for the product.
        return hashProductName ^ hashProductCode;
    }
