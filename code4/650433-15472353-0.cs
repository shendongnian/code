    var sb = GetScrollBar(gridControl1, ScrollBarType.Vertical);
    sb.Scroll += new ScrollEventHandler(sb_Scroll);
    //...
    void sb_Scroll(object sender, ScrollEventArgs e) {
        var scrollBar = sender as DevExpress.XtraEditors.ScrollBarBase;
        if(e.NewValue == (scrollBar.Maximum - scrollBar.LargeChange)) {
            MessageBox.Show("Last row is reached!");
        }
    }
    ScrollBarBase GetScrollBar(GridControl gridControl, ScrollBarType type) {
        foreach(Control c in gridControl.Controls) {
            var scrollBar = c as ScrollBarBase;
            if(scrollBar != null && scrollBar.ScrollBarType == type)
                return scrollBar;
        }
        return null;
    }
