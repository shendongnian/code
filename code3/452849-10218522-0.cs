     public class ValueContainer
     {
          protected Algo2 _reference = null;
          protected double _staticValue = 0;
          public double CurrentValue
          {
              get
              {
                  if(_reference == null)
                     return _staticValue;
               
                  return _reference.y;
              }
          }
          public ValueContainer(Algo2 reference)
          {
               _reference = reference;
          }
          public ValueContainer(double value)
          {
               _staticValue = value;
          }
     }
