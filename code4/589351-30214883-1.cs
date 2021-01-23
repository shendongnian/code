    /// <summary>
    /// Add a file entry with data.
    /// </summary>
    /// <param name="dataSource">The source of the data for this entry.</param>
    /// <param name="entryName">The name to give to the entry.</param>
    /// <param name="compressionMethod">The compression method to use.</param>
    /// <param name="useUnicodeText">Ensure Unicode used for name/comments for this entry.</param>
    /// <param name="comment">Comentario</param>
    public void Add(IStaticDataSource dataSource, string entryName,
        CompressionMethod compressionMethod, bool useUnicodeText, string comment)
    {
        if (dataSource == null)
        {
            throw new ArgumentNullException("dataSource");
        }
        if (entryName == null)
        {
            throw new ArgumentNullException("entryName");
        }
        CheckUpdating();
        ZipEntry entry = EntryFactory.MakeFileEntry(entryName, false);
        entry.IsUnicodeText = useUnicodeText;
        entry.CompressionMethod = compressionMethod;
        entry.Comment = comment;
        AddUpdate(new ZipUpdate(dataSource, entry));
    }
