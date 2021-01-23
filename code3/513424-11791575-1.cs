    public override string ToString()
    {
        if (!this.HasValue)
        {
            return "";
        }
        return this.value.ToString();
    }
