    public static class ExtensionMethods {
        public static bool IsNullOrEmpty(this ItemCapsule item) {
            return (item != null && item.MyItem != null);
        } 
    
        public static bool Equals(this ItemCapsule firstItem, ItemCapsule secondItem) {
            return (firstItem.MyItem.Equals(secondItem.MyItem)); //see below
        }
    
        public static bool Equals(this Item firstItem, Item secondItem) {
            // perform the comparison of your 'Item' objects here
        }
    }
