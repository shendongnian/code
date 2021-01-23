    // use generic dictionary instead of hashtable
    Dictionary<string, string> textChanges = new Dictionary<string, string>(50);
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyData == Keys.Z)
        {
            // retrieve focused textboxes via Linq
            foreach (var textBox in Controls.OfType<TextBox>().Where(x => x.Focused))
                textBox.Text = textChanges[textBox.Name];
        }
    }
