    class MyTextBox : TextBox
    {
        protected override void WndProc(ref Message m)
        {
            // Trap WM_PASTE:
            if (m.Msg == 0x302 && Clipboard.ContainsText())
            {
                var removedInvalid = from c in Clipboard.GetText()
                                     where XmlConvert.IsXmlChar(c)
                                     select c;
                SelectedText = new string(removedInvalid.ToArray());
                return;
            }
            base.WndProc(ref m);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!XmlConvert.IsXmlChar(e.KeyChar))
                e.Handled = true;
            base.OnKeyPress(e);
        }
    }
