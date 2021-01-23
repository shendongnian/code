    var selectedIndices = listView.SelectedIndices.Cast<int>().Reverse().ToList();
    listView.BeginUpdate();
    foreach (var index in selectedIndices) {
        listView.RemoveAt(index);
    }
    listView.EndUpdate();
