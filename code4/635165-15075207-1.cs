    public double LocationX
    {
       get
       {
           return Location.X;
       }
       set
       {
           Location = new Rectangle(value,Location.Y);
       }
    }
