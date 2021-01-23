    public class object_t 
    {    
        public static object_t CreateObjectT(string config, object_t default_obj)
        {
             object_t theconfiguredobject = new object_t();
    
             //try to configure it
    
             if( /*failed to initialize from config*/ )
             { 
                 return default_obj.Clone();
             }
             else
             {
                 return theconfiguredobject;
             }
        }
    }
