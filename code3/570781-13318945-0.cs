    class Apple : Fruit
    {
     public double Radius { get;set;}
     //public void apple(double radius)//Constructors need to share the same case 
                                     //as their parent and inherently have no return value
     public Apple(double radius)
     {
        //Radius = Radius;//This is a self reference
        Radius = radius;//This will reference the local variable to Apple, Radius
     }
    }
