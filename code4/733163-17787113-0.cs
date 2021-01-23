    public string Selection
    {
       get
       {
           Gtk.TextIter A;
           Gtk.TextIter B;
           if (textView.Buffer.GetSelectionBounds(out A, out B))
           {
               return textView.Buffer.GetText(A, B, true);
           }
           // return null when there is no selection
           return null;
       }
    }
