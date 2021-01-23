    // Custom comparer for the Item class
    class ItemComparer: IEqualityComparer<Product>
    {
        // Items are equal if their names and IDs are equal.
        public bool Equals(Item x, Item y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
        //Check whether the items' properties are equal.
        return x.ID == y.ID && x.Name == y.Name;
        }
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Item item)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(item, null)) return 0;
            //Get hash code for the Name field if it is not null.
            int hashItemName = item.Name == null ? 0 : item.Name.GetHashCode();
            //Get hash code for the ID field.
            int hashItemID = item.ID.GetHashCode();
            //Calculate the hash code for the item.
            return hashItemName ^ hashItemID;
        }
    }
