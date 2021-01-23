    public string str;
        private void linkLabel1_MouseEnter(object sender, EventArgs e)
        {
            str = Clipboard.GetText();
            linkLabel1.MouseDoubleClick+=new MouseEventHandler(linkLabel1_MouseDoubleClick);
        }
        private void linkLabel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(str);
        }
