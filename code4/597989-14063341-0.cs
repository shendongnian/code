    public class  object_t 
    { 
        int A, B;
        public object_t ( string config, object_t default_obj )
        {
             if( /*failed to initialize from config*/ )
             { 
                this.A = default_obj.A; 
                this.B = default_obj.B; 
                //...
             }
        }
    }
