    // base class
    public bool IsGarbage { get; set; }
    // child class
    public void Draw()
    {
         if(!IsGarbage)
         {
             // Do Stuff
         }
    }
