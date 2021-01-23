    var m_SessionNames = new List<string>();
    for (int i = 0; i < filenames.Length; i++)
    {
        var filename = filenames[i];
        if (string.IsNullOrWhiteSpace(filename))
        {
            MessageBox.Show("filename is null");
            continue;
        }
        MessageBox.Show(filename);
        
        m_SessionNames.Add(Path.GetFileName(filename));
    }
    return m_SessionNames.ToArray();
