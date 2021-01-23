    public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BillingModelType))
                return false;
            return ((BillingModelType)obj).BillingModelID == this.BillingModelID;
        }
    public override int GetHashCode()
        {
            return this.BillingModelID.GetHashCode();
        }
