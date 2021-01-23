    private void RichTextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
    	//aware of Paste or Insert
    	if (e.Control && e.KeyCode == Keys.V || e.Shift && e.KeyCode == Keys.I) {
    		if (Clipboard.ContainsImage || Clipboard.ContainsFileDropList) {
    			//some images are transferred as filedrops
    			e.Handled = true;
    			//stops here
    		} else if (Clipboard.ContainsData(DataFormats.Rtf)) {
    			RichTextBox rtbox = new RichTextBox();
    			//use a temp box to validate/simplify
    			rtbox.Rtf = Clipboard.GetData(DataFormats.Rtf);
    			this.RichTextBox1.SelectedRtf = this.removeRtfObjects(rtbox.Rtf);
    			rtbox.Dispose();
    			e.Handled = true;
    		}
    	}
    }
