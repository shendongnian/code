    private readonly int _hash;
    public Sample(string strA, string strB)
    {
        this._strA = strA;
        this._strB = strB;
        this._hash = (33 * (this._strA ?? "").GetHashCode())
                   + (this._strB ?? "").GetHashCode();
    }
    public override int GetHashCode()
    {
        return this._hash;
    }
    
