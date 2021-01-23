    private void lstColor_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        var g = Graphics.FromHwnd(lstColor.Handle);
        var sf = new StringFormat(StringFormat.GenericTypographic);
        var size = g.MeasureString(data[e.Index], oFont, 500, sf);
        var height = size.Height;
    
        e.ItemHeight = Convert.ToInt32(height);
    }
