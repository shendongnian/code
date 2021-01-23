    string path = Path.GetDirectoryName(textBox4.Text);
    string filename = Path.GetFileName(textBox4.Text);
    string invalid = new string(Path.GetInvalidPathChars());
    foreach (char ch in invalid) {
        path  = path.Replace(ch.ToString(), "");
    }
    path = path.Trim();
    invalid = new string(Path.GetInvalidFileNameChars());
    foreach (char ch in invalid) {
        filename = filename.Replace(ch.ToString(), "");
    }
    filename = filename.Trim();
    if (filename.Length > 0) {
        if (path.Length > 0) {
            filename = Path.Combine(path, filename);
        }
        bitmap.Save(filename);
    } else {
        // not a valid filename
    }
