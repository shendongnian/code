    private Dictionary<String, Func<IApplicationPrinter>> _converters;
    public void Initialise()
    {
        foreach (string ext in WordPrinter.PrintableExtensions)
        {
            converters.Add(ext, () => new WordPrinter());
        }
    }
    public IApplicationPrinter GetPrinterFor(String extension)
    {
        if (_converters.ContainsKey(extension))   //case sensitive!
        {
            return _converters[extension].Invoke();
        }
        throw new PrinterNotFoundException(extension);
    }
