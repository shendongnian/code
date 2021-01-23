    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox source = (TextBox)e.Source;
            TextChange t = e.Changes.First();
            string first = txt2.Text.Substring(0, t.Offset);
            string added = source.Text.Substring(t.Offset, t.AddedLength);
            string last = (t.Offset+1>tbrt.Text.Length)?"":txt2.Text.Substring(t.Offset, txt2.Text.Length-1);
            last = last.Remove(0, t.RemovedLength);
            txt2.Text = first + added + last;
        }
