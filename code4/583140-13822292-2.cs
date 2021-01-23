    public class ListSectionAdapter : BaseAdapter<ListSection>
    {
       private const int TYPE_SECTION_HEADER = 0;
       private Context _context;
       private List<ListSection> _sections;
       private LayoutInflater _inflater;
       public ListSectionAdapter(Context context)
       {
          _context = context;
          _inflater = Inflater.From(_context);
          _sections = new List<ListSection>();
       }
       public List<ListSection> Sections { get { return _sections; } set { _sections = value; } }
       public override int Count
       {
          get
          {
             int count = 0;
             foreach(ListSection s in _sections) count += s.Adapter.Count + 1;
             return count;
          }
       }
       public override int ViewTypeCount
       {
          get
          {
             int viewTypeCount = 1;
             foreach(ListSection s in _sections) viewTypeCount += s.Adapter.ViewTypeCount;
             return viewTypeCount;
          }
       }
       public override ListSection this[int index] { get { return _sections[index]; } }
       public override bool AreAllItemsEnable() { return false; }
       public override int GetItemViewType(int position)
       {
          int typeOffset = TYPE_SECTION_HEADER + 1;
          foreach(ListSection s in _sections)
          {
             if(position == 0) return TYPE_SECTION_HEADER;
             int size = s.Adapter.Count + 1;
             if(position < size) return (typeOffset + s.Adapter.GetItemViewType(position - 1));
             position -= size;
             typeOffset += s.Adapter.ViewTypeCount;
          }
          return -1;
       }
       public override long GetItemId(int position) { return position; }
       public void AddSection(String caption, String columnHeader1, String columnHeader2, String columnHeader3, BaseAdapter adapter)
       {
          _sections.Add(new ListSection(caption, columnHeader1, columnHeader2, columnHeader3, adapter);
       }
       public override View GetView(int position, View convertView, ViewGroup parent)
       {
          View view = convertView;
          foreach(ListSection s in _sections)
          {
             if(position == 0)
             {
                 if(view == null || !(view is LinearLayout)) view = _inflater.Inflate(Resource.Layout.SectionSeparator, parent, false);
                 TextView caption = view.FindViewById<TextView>(Resource.Id.caption);
                 caption.Text = s.Caption;
                 TextView columnHeader1 = view.FindViewById<TextView>(Resource.Id.columnHeader1);
                 columnHeader1.Text = s.ColumnHeader1;
                 TextView columnHeader2 = view.FindViewById<TextView>(Resource.Id.columnHeader2);
                 columnHeader2.Text = s.ColumnHeader2;
                 TextView columnHeader3 = view.FindViewById<TextView>(Resource.Id.columnHeader3);
                 columnHeader3.Text = s.ColumnHeader3;
                 return view;
              }
              int size = s.Adapter.Count + 1;
              if(position < size) return s.Adapter.GetView(position - 1, convertView, parent);
              position -= size;
           }
           return null;
        }
        public override Java.Lang.Object GetItem(int position)
        {
           foreach(ListSection s in _sections)
           {
              if(position == 0) return null;
              int size = s.Adapter.Count + 1;
              if(position < size) return s.Adapter.GetItem(position);
              position -= size;
           }
           return null;
        }
     }
