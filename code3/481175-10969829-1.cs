    class OutPointContainer { //Please, think of a better name :)
        public Point OutPoint{ get; set; }
    }
    class Tool
    {
    public Action Select;
    public Action Cancel;
    public Point position;
    
    public Tool(OutPointContainer outPointContainer)
    {
        Select = () => outPoint.OutPoint = position;
    }
    
    public void Update(Point newPosition)
    {
    position = newPosition
    }
    public void UpdateKey(Keys k, bool IsPress)
    {
    //Invoke Select/Cancel when press some keys
    }
    
    }
