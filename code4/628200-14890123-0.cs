    public bool IsPublic {
        get {
            return ((this.Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.Public);
        }
    }
