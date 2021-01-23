    abstract class Square<TFigure> where TFigure : Shape
    {
      public float Side {set; get;}
    
      protected Square(TFigure stereotype)
      {
         Side = GetStereotypeSide(stereotype) 
      }
    
      public abstract float GetStereotypeSide(TFigure stereotype);
    }
