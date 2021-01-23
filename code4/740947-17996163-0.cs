    public class AssetMarkupComparer : IEqualityComparer<AssetMarkup>
    {
        public bool Equals(AssetMarkup am1, AssetMarkup am2)
        {
            return am1.AssetId == am2.AssetId;
        }
    
        public int GetHashCode(AssetMarkup obj)
        {
            return obj.AssetId.GetHashCode();
        }
    }
    
    var complement = defaults.Except(notDefaults, new AssetMarkupComparer());
