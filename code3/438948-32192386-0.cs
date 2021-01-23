    public partial class Form1 : Form
    {
        private Cursor defaultRichTextBoxCursor = Cursors.Default;
        private const string HOT_TEXT = "click here";
        private bool mouseOnHotText = false;
        // ... Lines skipped (constructor, etc.)
        private void Form1_Load(object sender, EventArgs e)
        {
            // save the right cursor for later
            this.defaultRichTextBoxCursor = richTextBox1.Cursor;
            richTextBox1.SelectionFont = new Font("Calibri", 11, FontStyle.Underline);
            richTextBox1.SelectionColor = Color.Blue;
            // output "click here" with blue underlined font
            richTextBox1.SelectedText = HOT_TEXT + "\n";
            richTextBox1.SelectionFont = new Font("Calibri", 11, FontStyle.Regular);
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectedText = "Some regular text";
        }
        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int mousePointerCharIndex = richTextBox1.GetCharIndexFromPosition(e.Location);
            int mousePointerLine = richTextBox1.GetLineFromCharIndex(mousePointerCharIndex);
            int firstCharIndexInMousePointerLine = richTextBox1.GetFirstCharIndexFromLine(mousePointerLine);
            int firstCharIndexInNextLine = richTextBox1.GetFirstCharIndexFromLine(mousePointerLine + 1);
            if (firstCharIndexInNextLine < 0)
            {
                firstCharIndexInNextLine = richTextBox1.Text.Length;
            }
            // See where the hyperlink starts, as long as it's on the same line
            // over which the mouse is
            int hotTextStartIndex = richTextBox1.Find(
                HOT_TEXT, firstCharIndexInMousePointerLine, firstCharIndexInNextLine, RichTextBoxFinds.NoHighlight);
            if (hotTextStartIndex >= 0 && 
                mousePointerCharIndex >= hotTextStartIndex && mousePointerCharIndex < hotTextStartIndex + HOT_TEXT.Length)
            {
                // Simulate hyperlink behavior
                richTextBox1.Cursor = Cursors.Hand;
                mouseOnHotText = true;
            }
            else
            {
                richTextBox1.Cursor = defaultRichTextBoxCursor;
                mouseOnHotText = false;
            }
            toolStripStatusLabel1.Text = mousePointerCharIndex.ToString();
        }
        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mouseOnHotText)
            {
                // Insert your own URL here, to navigate to when "hot text" is clicked
                Process.Start("http://www.google.com");
            }
        }
    }
