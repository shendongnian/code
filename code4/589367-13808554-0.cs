    public IEnumerable<CaseFire> Find(string xmlDoc)
    {
       var xdoc = XDocument.Load(xmlDoc)
       return from e in xdoc.Root.Elements("application-information")
                                 .Elements("file-segments")
                                 .Elements("action-keys")
                                 .Elements("case-file")
              select new CaseFile {};
    }
