    var source = FileBrowseBox.Text;
    var target = Path.Combine(DestinationBox.Text, Path.ChangeExtension(FileNameBox.Text, Path.GetExtension(source)));
    if (File.Exists(target))
    {
        File.Delete(target);
    }
    File.Move(source, target);
