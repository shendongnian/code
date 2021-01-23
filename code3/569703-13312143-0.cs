     public View GetView(int pos, View convertView)
     {
         TextView toShow = convertView as TextView;
         if (toShow == null)
         {
            toShow = new TextView();
         }
         toShow.Text = "Item at position " + i;
         toShow.Click += (s,e) => {
             // do something
         };
         return toShow;
     }
