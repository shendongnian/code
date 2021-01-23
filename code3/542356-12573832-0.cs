    public static string ColorText(string text) {
        using (var rtb = new System.Windows.Forms.RichTextBox()) {
            rtb.Text = text;
            return rtb.Rtf;
        }
    }
