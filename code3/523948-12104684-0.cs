    public class CustomSpinnerAdapter : BaseAdapter
    {
        readonly Activity _context;
        private List<Users> _items;
        public ComboBoxAdapter(Activity context, List<Users> listOfItems)
        {
            _context = context;
            _items = listOfItems;
        }
        public override int Count
        {
            get { return _items.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            var view = (convertView ?? context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleSpinnerDropDownItem,
                parent,
                false));
            var name = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            name.Text = item.Name;
            return view;
        }
        public Users GetItemAtPosition(int position)
        {
            return _items[position];
        }
    }
