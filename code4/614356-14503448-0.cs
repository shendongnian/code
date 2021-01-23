    SubscribeScrollEvent(listBoxControl1);    // Before start items adding
    bw.RunWorkerAsync();
    //...
    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
        UnsubscribeScrollEvent(listBoxControl1);  // After items adding complete 
    }
    void bw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
        listBoxControl1.Items.Add(e.ProgressPercentage);
        if(!userScrollPerformed)
            listBoxControl1.SelectedIndex = listBoxControl1.Items.Count - 1;
    }
    //...
    void SubscribeScrollEvent(ListBoxControl listBox) {
        var hScroll = listBox.Controls[0] as DevExpress.XtraEditors.HScrollBar;
        var vScroll = listBox.Controls[1] as DevExpress.XtraEditors.VScrollBar;
        vScroll.Scroll += ListBox_Scroll;
        hScroll.Scroll += ListBox_Scroll;
    }
    void UnubscribeScrollEvent(ListBoxControl listBox) {
        var hScroll = listBox.Controls[0] as DevExpress.XtraEditors.HScrollBar;
        var vScroll = listBox.Controls[1] as DevExpress.XtraEditors.VScrollBar;
        vScroll.Scroll -= ListBox_Scroll;
        hScroll.Scroll -= ListBox_Scroll;
    }
    bool userScrollPerformed;
    void ListBox_Scroll(object sender, ScrollEventArgs e) {
        if(e.Type == ScrollEventType.ThumbTrack)
            userScrollPerformed = true; // set a flag
    }
