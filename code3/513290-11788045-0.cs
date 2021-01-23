    namespace Covariance
    {
        public class MyContainer
        {
            public string ContainerName { get; set; }
            public IList<Square> MySquares { get; set; }
            public IList<Circle> MyCircles { get; set; }
            public MyContainer() {
                MySquares = new List<Square>();
                MyCircles = new List<Circle>();
            }
        }
    
        public class Shape
        {
            public int Area { get; set; }
        }
    
        public class Square : Shape
        {
        }
    
        public class Circle : Shape
        {
        }   
        
        class Program
        {
            static void Main( string[] args ) {
    
                MyContainer mc = new MyContainer();
                mc.MyCircles.Add( new Circle { Area = 60 } );
    
                Collect( mc );
                Console.ReadLine();
            }
    
            private static void Collect( MyContainer container ) {
                var properties = container.GetType().GetProperties();
                foreach( var property in properties ) {
                    if( property.PropertyType.IsGenericType &&
                        property.PropertyType.GetGenericTypeDefinition() == typeof( IList<> ) &&
                        typeof( Shape ).IsAssignableFrom( property.PropertyType.GetGenericArguments()[0] ) ) {
                        var t = property.GetValue( container, null ) as IEnumerable<Shape>;
                        if( t != null ) {
                            foreach( Shape shape in t ) {
                                Console.WriteLine( shape.Area );
                            }
                        }
                    }
                }
            }
        }
    }
