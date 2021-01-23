    private void lstColor_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        var g = Graphics.FromHwnd(lstColor.Handle);
        var sf = new StringFormat(StringFormat.GenericTypographic);
        var size = new SizeF();
        var height = new Single();
    
        height = 0;
    
        var oFont = new Font("Arial", 10);
    
        size = g.MeasureString(data[e.Index], oFont, 500, sf);
        height = size.Height;
        e.ItemHeight = Convert.ToInt32(height);
    }
