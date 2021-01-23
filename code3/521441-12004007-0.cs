    public class MyData{
        public static List<MyData> Items;
        static MyData(){
            Items=new List<MyData>();
            // load items to the list
        }
    
        public string Name {get;set;}
        public string Value {get;set;}
        public string Info {get;set;}
    }
