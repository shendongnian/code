    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((Control.ModifierKeys & Keys.Control) == Keys.Control && (e.KeyChar == 'V' || e.KeyChar == 'v'))
            if (((int)e.KeyChar) == 22)
            {
                if(hasImage(Clipboard.GetDataObject()));
                {
                    e.Handled = true;
                    richTextBox1.Undo();
                    MessageBox.Show("can't paste image here!!");
                }
            }
        }
        private Boolean hasImage(object obj)
        {
            System.Windows.Forms.RichTextBox richTextBox = new System.Windows.Forms.RichTextBox();
            Object data = Clipboard.GetDataObject();
            Clipboard.SetDataObject(data);
            richTextBox.Paste();
            Clipboard.SetDataObject(data);
            int offset = richTextBox.Rtf.IndexOf(@"\f0\fs17") + 8; // offset = 118;
            int len = richTextBox.Rtf.LastIndexOf(@"\par") - offset;
            return richTextBox.Rtf.Substring(offset, len).Trim().Contains(@"{\pict\");
        }
