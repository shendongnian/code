     private static int[] _someArray = null;
     public override int[] someArray { 
         get {
              return _someArray ?? (_someArray = new int[] { 1,2,3,4 });
         }
     }
