    class ModContext
    {
        public ModContext(int first, int second)
        {
            this.First = first;
            this.Second = second;
            this.Result = this.First % this.Second;
        }
    
        public int First { get; private set; }
    
        public int Second { get; private set; }
    
        public int Result { get; private set; }
    }
    
    IList<ModContext> items = new List<ModContext>
        {
                new ModContext(10, 20),
                new ModContext(30, 40)
        };
    
    this.repeater.DataSource = items;
    this.repeater.DataBind();
