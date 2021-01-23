    private void RenderEntryValue (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
    {
        (cell as Gtk.CellRendererText).Markup = "" + someMarkupText;
        (cell as Gtk.CellRendererText).Alignment = Pango.Alignment.Center;
        cell.Xalign = 0.5f;
    }
