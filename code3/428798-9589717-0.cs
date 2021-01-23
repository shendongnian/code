    public class ListTest
    {
        public int[] Array { get; set; }
        public List<int> List { get; set; }
        public ListTest()
        {
         
        }
        public void Init() {
            Array = new[] { 1, 2, 3, 4 };
            List = new List<int>(Array);
        }
    }
    ListTest listTest = new ListTest();
    listTest.Init(); //manually call this to do the initial seed
