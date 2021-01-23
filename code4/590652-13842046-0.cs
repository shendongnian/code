    var files = await ApplicationData.Current.LocalFolder.GetFileAsync(logid.Text + ".txt");
    var lines = await FileIO.ReadLinesAsync(files);
    var pattern = sm.SelectedItem.ToString();
    // try to look up a line in the list the has the pattern we're looking for in it.
    var targetLine = lines.FirstOrDefault(line => line.Contains(pattern));
    if (!string.IsNullOrEmpty(targetLine))
        lv.items.add(targetLine);
