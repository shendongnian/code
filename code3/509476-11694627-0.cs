    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.Runtime;
    namespace FileChooser
    {
        public class FileArrayAdapter : BaseAdapter<Option>
        {
    
            private Context c;
            private int id;
            private List<Option> items;
    
            public FileArrayAdapter(Context context, int textViewResourceId,
                    List<Option> objects)
              
            {
    
                c = context;
                id = textViewResourceId;
                items = objects;
            }
    
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View v = convertView;
                if (v == null)
                {
                    LayoutInflater vi = (LayoutInflater)c.GetSystemService(Context.LayoutInflaterService);
                    v = vi.Inflate(id, null);
                }
                Option o = items[position];
                if (o != null)
                {
                    TextView t1 = (TextView)v.FindViewById(Resource.Id.TextView01);
                    TextView t2 = (TextView)v.FindViewById(Resource.Id.TextView02);
    
                    if (t1 != null)
                        t1.Text = o.getName().ToString();
                    if (t2 != null)
                        t2.Text = o.getData().ToString();
    
                }
                return v;
            }
    
    
    
            public override Option this[int position]
            {
                get { return items[position]; }
            }
    
            public override int Count
            {
                get { return items.Count; }
            }
    
            public override long GetItemId(int position)
            {
                return position;
            }
    
        }
    
    }
