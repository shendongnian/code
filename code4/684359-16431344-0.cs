    ISet<string> enabled = new HashSet<string>(
        options.Extensions.Where(e=>e.enabled).Select(e=>e.name)
    );
    IEnumerable<FileInfo> files = folderPath.EnumerateFiles();
    return files.Where(f => enabled.Contains(f.Extension));
