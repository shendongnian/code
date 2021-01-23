    public class Priority{
        public int PriorityId {get;set;}
        public string Label {get;set;}
    }
    public class CachedItems {
        private static List<Priority> _priorityList=new List<Priority>();
        public static List<Priority> GetPriorityList() {
            if (_priorityList==null){
                 // Load DB Items to the _priorityList, 
                 // if the app is multithreaded, you might wanna add some locks here
            }
        }
    }
