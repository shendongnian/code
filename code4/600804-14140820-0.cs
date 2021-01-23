        private Control clipBoardRef;
        private void btnCopy_Click(object sender, EventArgs e) {
            clipBoardRef = myButton1;
            Clipboard.SetData("myControl", "it doesn't matter");
        }
        private void btnPaste_Click(object sender, EventArgs e) {
            if (Clipboard.ContainsData("myControl")) {
                Control ctl = clipBoardRef;
                // etc...
            }
        }
