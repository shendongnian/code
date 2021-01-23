    public static void AutoResizeAllColumns( this ListView listView )
    {
        if ( listView.Columns.Count == 0 ) return;
        var lGraphics = Graphics.FromHwnd( listView.Handle );
        foreach ( ColumnHeader lColumnHeader in listView.Columns )
        {
            var lColumnHeaderTextSize = lGraphics.MeasureString( lColumnHeader.Text, listView.Font );
            var lColumnIndex = lColumnHeader.Index;
            var lAnyContents = listView.Items
                .Cast<ListViewItem>()
                .Select( x => lGraphics.MeasureString( x.SubItems[ lColumnIndex ].Text, listView.Font ) )
                .Any( x => x.Width > lColumnHeaderTextSize.Width );
            lColumnHeader.AutoResize( lAnyContents ? ColumnHeaderAutoResizeStyle.ColumnContent : ColumnHeaderAutoResizeStyle.HeaderSize );
        }
    }
