     public View GetView(int pos, View convertView)
     {
         TextView toShow = convertView as TextView;
         if (toShow == null)
         {
            toShow = new TextView();
            toShow.Click += (s,e) => {
                // do something with the position embedded in toShow.Tag
            };
         }
         toShow.Text = "Item at position " + i;
         toShow.Tag = new WrappedPosition(i);
         return toShow;
     }
