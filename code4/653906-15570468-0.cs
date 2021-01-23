    class Program
        {
            static void Main(string[] args)
            {
               
    
                //register the types
                List<Type> types = new List<Type>() { typeof(OShape), typeof(PShape), typeof(RShape) };
                
                // randomly select one
                Type type = types[1];
    
                // invoke the ctor
                ConstructorInfo ctor = type.GetConstructor(/*optional param for ctor, none in this case*/ new Type[] {} );
                object instance = ctor.Invoke(new object[] {});
    
                // you can safely cast to Shape
                Shape shape = (Shape)instance; //this is a PShape!
                
            }
        }
    
        class Shape
        {
        }
    
        class OShape : Shape
        {
        }
    
        class PShape : Shape
        {
        }
    
        class RShape : Shape
        {
        }
