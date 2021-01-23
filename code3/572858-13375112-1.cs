    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        OrderLineItem item = GetItemAtPosition(position);
        var view = convertView;
        if (view == null)
        {
            view = Context.LayoutInflater.Inflate(Resource.Layout.CustomListItem, parent, false)) as LinearLayout;
           
            var removeButton = view.FindViewById(Resource.Id.btnRemove) as Button;
            removeButton.Click += (s, e) => {
                var originalView = (View)s;
                var originalItem = originalView.Tag as MvxJavaContainer<OrderLineItem>;
                Items.Remove(originalItem);
                this.NotifyDataSetChanged();
            };
        }
        // ...........
        var tagButton = view.FindViewById(Resource.Id.btnRemove) as Button;
        tagButton.Tag = new MvxJavaContainer<OrderLineItem>(item);
        return view;
    }
