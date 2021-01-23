    private Lazy<IEnumerable<int>> _blocks;
    
    public MyClass()
    {
       _blocks = new Lazy<IEnumerable<int>>(
             () => this.CalculateBlocks(0).FirstOrDefault());
    }
    public IEnumerable<int> Blocks
    {
        get
        {
            return _blocks.Value
        }
    }
