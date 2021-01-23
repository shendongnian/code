    public bool Exists(Dog other) {
        foreach (Dog item in Items) {
            if (item.Name == other.Name && item.Owner == other.Owner)
                return true;
        }
    
        return false;
    }
