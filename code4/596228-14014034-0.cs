    public override int GetHashCode()
    {
        return pType.GetHashCode() ^ pSubType.GetHashCode() ^ quantityDiscountsDT.GetHashCode();
        //or something similar, but fast.
    }
    public bool Equals(QuantityBasedDiscount other)
    {
       if (ReferenceEquals(null, other))
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        return pType == other.pType && pSubType == other.pSubType && 
               quantityDiscountsDT == other.quantityDiscountsDT;
    }
