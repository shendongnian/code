    public class RecordItemEqualityComparer : IEqualityComparer<RecordItem>
    {
        public bool Equals(RecordItem x, RecordItem y)
        {
            if (x.AssetID != y.AssetID)
                return false;
            if (x.BuyerID == y.BuyerID && x.SellerID == y.SellerID)
                return true;
            if (x.BuyerID == y.SellerID && x.SellerID == y.BuyerID)
                return true;
            return false;
        }
        public int GetHashCode(RecordItem obj)
        {
            return string.Format("{0}_{1}", obj.BuyerID * obj.SellerID, obj.AssetID).GetHashCode();
        }
    }
