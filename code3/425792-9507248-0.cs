    public class SurfaceType
    {
        public static SurfaceType Rough  = new SurfaceType{Id=1, Description="Rough"};
        public static SurfaceType Smooth  = new SurfaceType{Id=2, Description="Smooth"};
        public static SurfaceType Mirror  = new SurfaceType{Id=3, Description="Mirror"};
        private SurfaceType()
        {
        }
        public int Id {get private set;}
        public string Description {get private set;}
 
        //override equality and hashcode is necessary.
    }
