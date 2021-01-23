    public class Context {
       public Point BeginPoint;
       public Point EndPoint;
       public List Points;
       whatever else
    }
    public class ShapeFactory {
       List<FactoryWorker> workers;
       public Shape CreateShape( string ShapeName, Context context )
       {
          foreach ( FactoryWorker worker in workers )
             if ( worker.Accepts( ShapeName ) )
                 return worker.CreateShape( context );
       }
       public void AddWorker( FactoryWorker worker ) {
          workers.Add( worker );
       }
     }
     public abstract class FactortWorker {
        public abstract bool Accepts( string ShapeName );
        puboic Shape CreateShape( Context context );
     }
     public class PolyLineFactoryWorker : FactoryWorker {
   
        public override bool Accepts( string ShapeName ) {
           return ShapeName == "polyline";
        }
        public Shape CreateShape( Context context ) { ... }
     }
