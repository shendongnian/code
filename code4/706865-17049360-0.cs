    private epub(string newFilename)
    {
        _contents = new List<epubChapter>();
        filename = newFilename;
    }
    public static async Task<epub> CreateAsync(string newFilename)
    {
        var result = new epub(newFilename);
        await result.UnZipFile();
        result.getTableOfContents();
        return result;
    }
