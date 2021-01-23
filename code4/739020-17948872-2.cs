    public class MyObj
    {
        public int id { get; set; }
        public string name{ get; set; }
    }
    // viewmodel
    public class MyviewModel
    {
        public IQuerable<MyObj> MyObjs{get;set;}
        public Other Other{get;set;}
    }
