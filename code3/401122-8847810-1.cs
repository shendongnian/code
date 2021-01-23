    public class MyData
    {
        private List<MyData> allMyDatas = new List<MyData>();
        public string Device {get; private set;}
        public string Status {get; private set;}
        public string Revision {get; private set;}
        public string Number {get; private set;}
        public string Ledmo {get; private set;}
        private MyData() // Private ctor ensures only a member 
        {                // function can create a new MyData
        }
        public static MyData Create()
        {
            var newData = new MyData();
            allMyDatas.Add(newData);
        }
        public static void Delete(MyData itemToRemove)
        {
            allMyDatas.Remove(itemToRemove);
        }
    }
