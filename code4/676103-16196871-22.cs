    public struct Frame
    {
       public Frame(int index, double position)
       {
          this.index = index; 
          this.position = position;
       }
       
       public int index {get;private set;}
       public double position {get;private set;}
    }
   
