    public class AssetClass : IEquatable<AssetClass>
    {
        public string FEE_ID { get; set; }
        public string ASSET_CLASS { get; set; }
        public bool Equals(AssetClass other)
        {
            return !ReferenceEquals(other, null) && other.FEE_ID == FEE_ID && other.ASSET_CLASS == ASSET_CLASS;
        }
        //Check to see if obj is a value-equal instance of AssetClass, if it's not, proceed
        //  to doing some reflection checks to determine value-equality
        public override bool Equals(object obj)
        {
            return Equals(obj as AssetClass) || PerformReflectionEqualityCheck(obj);
        }
        //Here's where we inspect whatever other thing we're comparing against
        private bool PerformReflectionEqualityCheck(object o)
        {
            //If the other thing is null, there's nothing more to do, it's not equal
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            //Get the type of whatever we got passed
            var oType = o.GetType();
            //Find the ID property on it
            var oID = oType.GetProperty("ID");
            //Get the value of the property
            var oIDValue = oID.GetValue(o, null);
            //If the property type is string (so that it matches the type of FEE_ID on this class
            //   and the value of the strings are equal, then we're value-equal, otherwise, we're not
            return oID.PropertyType == typeof (string) && FEE_ID == (string) oIDValue;
        }
    }
