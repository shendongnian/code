    static readonly int nullableDefaultHashCode = GetRandomInt32();
    public override int GetHashCode()
    {
        if (!this.HasValue)
            return nullableDefaultHashCode;
        else
            return this.value.GetHashCode();
    }
