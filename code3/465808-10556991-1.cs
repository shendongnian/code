    private readonly IList<string> elements = new List<string>();
    public void ProcessElements()
    {
        lock (this.elements)
        {
            foreach (string element in this.elements)
                ProcessElement(element);
        }
    }
    public void AddElement(string newElement)
    {
        lock (this.elements)
        {
            this.elements.Add(element);
        }
    }
