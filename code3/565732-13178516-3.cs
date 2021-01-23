    public float Value { get; set; }
    #region IEquatable<float> Members
    public bool Equals(float other)
    {
        return Equals(other, Constants.Exact);
    }
    #endregion
    public bool Equals(float other, bool exact)
    {
        if (exact)
            return Value == other;
        else
            return Math.Floor(Value) == Math.Floor(other);
    }
