    public override bool Equals(object obj)
    {
        var item = obj as RecommendationDTO;
        if (item == null)
        {
            return false;
        }
        return this.RecommendationId.Equals(item.RecommendationId);
    }
    public override int GetHashCode()
    {
        return this.RecommendationId.GetHashCode();
    }
