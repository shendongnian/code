    public class ConcurentList {
        private object sync = new object(); 
        private List<object> realList = new List<object>(); 
    
    
        public void Add(object o) {
            lock(sync){
               realList.Add(o);
            }
        }   
        /** ADD OTHERE METHODS IMPEMENTATION IF NEED **/
    
    }
