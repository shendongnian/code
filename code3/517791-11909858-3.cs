        public static void Main()
        {
            string sInput = "hi\t bye\t\n";// one\t two\t\n";
            SIZE CharSize;
            Form form = new Form();
            RichTextBox rtfBox = new RichTextBox();
            rtfBox.ContentsResized += (object sender, ContentsResizedEventArgs e) =>
            {
                var richTextBox = (RichTextBox)sender;
                richTextBox.Width = e.NewRectangle.Width;
                richTextBox.Height = e.NewRectangle.Height;
                rtfBox.Width += rtfBox.Margin.Horizontal + SystemInformation.HorizontalResizeBorderThickness;
            };
            rtfBox.WordWrap = false;
            rtfBox.ScrollBars = RichTextBoxScrollBars.None;
            rtfBox.Rtf = @"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil Arial;}}\viewkind4\uc1\trowd\trgaph100\cellx1000\cellx2000\pard\intbl\lang1033\f0\fs20  hi\cell  bye\cell\row\intbl  one\cell  two\cell\row\pard\par}";
            form.Controls.Add(rtfBox);
            form.ShowDialog();
        }
