    var node = item.Tag as FileNode;
    stuffFile.Position = node.FileOffset;
    string temp = Path.GetTempPath();
    using (var output = File.Create(Path.Combine(temp, node.Name)))
        stuffFile._stream.CopyTo(output);
    System.Diagnostics.Process.Start(Path.Combine(temp, node.Name));
