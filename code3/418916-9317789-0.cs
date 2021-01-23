    public override bool Equals(System.Object obj)
    {
        // Check if the object is a RecommendationDTO.
        // The initial null check is unnecessary as the cast will result in null
        // if obj is null to start with.
        var recommendationDTO = obj as RecommendationDTO;
    
        if (recommendationDTO == null)
        {
            // If it is null then it is not equal to this instance.
            return false;
        }
    
        // Instances are considered equal if the ReferenceId matches.
        return this.ReferenceId == recommendationDTO.ReferenceId;
    }
    public override int GetHashCode()
    {
        // Returning the hashcode of the Guid used for the reference id will be 
        // sufficient and would only cause a problem if RecommendationDTO objects
        // were stored in a non-generic hash set along side other guid instances
        // which is very unlikely!
        return this.ReferenceId.GetHashCode();
    }
