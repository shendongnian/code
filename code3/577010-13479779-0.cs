    public class GClass1 : KeyedCollection<string, GClass2>
    {
        protected override string GetKeyForItem(GClass2 item)
        {
            throw new NotImplementedException();
        }
    
        public string GetKey(GClass2 item)
        {
            return GetKeyForItem(item);
        }
    }
