    var changed = e.NewValues.Cast<DictionaryEntry>()
        .Where(entry => entry.Value != e.OldValues[entry.Key])
        .Select(entry => String.Format("{0} was edited with {1}",entry.Key,entry.Value));
    var notChanged = e.NewValues.Cast<DictionaryEntry>()
        .Where(entry  => entry.Value == e.OldValues[entry.Key])
        .Select(entry => String.Format("{0} was not changed",entry.Key));
 
    TxtChanged.Text = String.Join(Environment.NewLine, changed);
    TxtUnchanged.Text = String.Join(Environment.NewLine, notChanged);
