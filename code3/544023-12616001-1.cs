    string oldtext = "";
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string removedstring = "";
        string addedstring = "";
        TextBox source = (TextBox)e.Source;
        TextChange t = e.Changes.First();
        if (t.RemovedLength > 0)
        {
            removedstring = oldtext.Substring(t.Offset, t.RemovedLength);
        }
        if (t.AddedLength > 0)
        {
            addedstring = source.Text.Substring(t.Offset, t.AddedLength);
        }
        oldtext = source.Text;
    }
