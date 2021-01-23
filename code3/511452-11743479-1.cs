    public override int GetHashCode()
    {
        // omit null-coalesce if we know them to be non-null
        return (33 * (this._strA ?? "").GetHashCode())
             + (this._strB ?? "").GetHashCode();
    }
