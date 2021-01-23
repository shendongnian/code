    abstract class polygon
    {
        abstract decimal ComputeArea();
    }
    class Triangle : Polygon
    {
         public decimal Base {get;set;}
         public decimal Height {get;set;}
         public override decimal ComputeArea()
         {
              return Base * Height / 2;
         }
    }
    class class Square : Polygon
    {
         public decimal Side {get;set;}
         public override decimal ComputeArea()
         {
              return Side * 4;
         }
    }
    class class Circle : Polygon
    {
         public decimal Radius {get;set;}
         public override decimal ComputeArea()
         {
              return Math.Square(Math.Pi * Radius);
         }
    }
