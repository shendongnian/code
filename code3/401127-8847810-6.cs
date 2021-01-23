    public class MyData
    {
        private static List<MyData> allMyDatas = new List<MyData>();
        public static IEnumerable<MyData> AllInstances
        {
            get {return allMyDatas;}
        }
        public string Device {get; set;}
        public string Status {get; set;}
        public string Revision {get; set;}
        public string Number {get; set;}
        public string Ledmo {get; set;}
        private MyData() // Private ctor ensures only a member 
        {                // function can create a new MyData
        }
        public static MyData Create()
        {
            var newData = new MyData();
            allMyDatas.Add(newData);
            return newData;
        }
        public static void Delete(MyData itemToRemove)
        {
            allMyDatas.Remove(itemToRemove);
        }
    }
