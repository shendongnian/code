    class ClearanceListAdapter : BaseAdapter
    {
        private readonly List<Clearance> _clearances;
        private readonly Activity _context;
        public ClearanceListAdapter(List<Clearance> Clearances, Activity context)
        {
            _clearances = Clearances;
            _context = context;
        }
        public override int Count
        {
            get { return _clearances.Count(); }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public Clearance GetClearance (int position)
        {
            return _clearances.ElementAt(position);
        }
        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            View view = (convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.ClearanceListItem, parent, false));
            Clearance clearance = _clearances[position];
                   
               
            view.FindViewById<TextView>(Resource.Id.txtClearanceDescription).Text = clearance.Description;
            view.FindViewById<TextView>(Resource.Id.txtStartDate).Text = clearance.Start.ToString("g");
            view.FindViewById<TextView>(Resource.Id.txtEndDate).Text = clearance.End.ToString("g");
            return view;
        }
    }
