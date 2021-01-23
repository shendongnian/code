    private IList<string> elements = new List<string>();
    private readonly object syncLock = new object();
    public void ProcessElements()
    {
        lock (this.syncLock)
        {
            foreach (string element in this.elements)
                ProcessElement(element);
        }
    }
    public void AddElement(string newElement)
    {
        lock (this.syncLock)
        {
            this.elements.Add(element);
        }
    }
