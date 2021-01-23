    public override int GetHashCode()
    {
        return this.name.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        var other = obj as CustomClass;
        if (other != null)
        {
            if (other.Name == this.Name)
            {
                 return true;
            }
        }
        return false;
    }
