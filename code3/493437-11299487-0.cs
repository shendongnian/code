     public interface ibeta {
        void hello();
     }
     ..
      
     public static void Main()
     {
         // resolve type by its fully qualified name
         ibeta b = (ibeta)Activator.CreateInstance( Type.GetType( "beta, B" ) );
         b.hello(); 
     }
