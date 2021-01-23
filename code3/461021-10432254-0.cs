    public override bool Equals(object other)
    {
        // The following type check is not needed with IEquatable<Pair<T1, T2>>
        Pair<T1, T2> pair = other as Pair<T1, T2>;
        if (pair != null)
        {
            // <-- IEquatable<Pair<T1, T2>> implementation
        }
        else
        {
            return base.Equals(other);
        }
    }
