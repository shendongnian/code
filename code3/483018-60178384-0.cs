    public class EfBindingList<T> : BindingList<T>
        where T : class
    {
        public EfBindingList(IList<T> lst) : base(lst)
        {
        }
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            var foundItem = Items.FirstOrDefault(x => prop.GetValue(x) == key);
            // Ignore the prop value and search by family name.
            for (int i = 0; i < Count; ++i)
            {
                var item = Items[i];
                if (prop.GetValue(item).ToString() == key.ToString()) return i;
            }
            return -1;
        }
    }
