    class Program {
        static void Main( string[ ] args ) {
          Dictionary< long, Tuple <input, output> > dict = new Dictionary<long,Tuple<input,output>> () ;
          for (long i = 0 ;  i < (long) (2^28) ;  i++) {
            input ip = new input( );
            output op = new output( );
            for( int j = 0; j < 8; j++ ) {
              //you have to write your own lodic for creating input and output
              unit isp = new unit( );
              unit osp = new unit( );
              ip.iData[ j ] = isp;
              op.oData[ j ] = osp;
            }
            dict.Add( i, Tuple.Create( ip, op ) );
          }    
        }
      }
    
      public class input {
        public  unit [] iData = new unit [8] ; 
      }
    
      public class output {
        public unit[ ] oData = new unit[ 8 ];
      }
    
      public class unit {
        public int item1;
        public int item2;
        public int item3;
      }
