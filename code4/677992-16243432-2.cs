    public override int GetHashCode()
    {
        return X.GetHashCode() * 19 + Y.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        var other = obj as customPoint;
        return this.X == other.X && this.Y == other.Y;
    }
