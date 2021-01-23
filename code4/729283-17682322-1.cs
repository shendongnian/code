    public double Width
    {
       get { return width; }
       set
       {
             width = value;
             mySize = new Size(width, Height); // Compute new size, so it's always correct
       }
    }
