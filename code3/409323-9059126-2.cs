    public override bool Equals(object obj)
    {
        return this.Equals(obj as Tags);
    }
    public bool Equals(Tags tags)
    {
        return (object)tags != null && this.mask == tags.mask;
    }
    public override int GetHashCode()
    {
        return this.mask.GetHashCode();
    }
