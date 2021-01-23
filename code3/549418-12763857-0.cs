    private List<FileTuple> FindDuplicates()
    {
        return Directory.EnumerateFiles(txtFolderPath.Text, "*.*", 
                                        SearchOption.AllDirectories)
                        .Where(str => str.Contains(".exe") || 
                               str.Contains(".zip")
                        .Select(str => new FileTuple { 
                                   FileName = Path.GetFileName(str),
                                   ContainingFolder = Path.GetDirectoryName(str))
                                })
                        .GroupBy(tuple => tuple.FileName)
                        .Where(g => g.Count() > 1) // Only keep duplicates
                        .OrderBy(g => g.Key)       // Order by filename
                        .SelectMany(g => g)        // Flatten groups
                        .ToList();                     
    }
