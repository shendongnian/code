    //[DataContract] - pick one of them
    //[Serializable] - they are required, but without seeing your code, it is hard to tell which one
    public class MyWebServiceParameter
    {
        public string aaaa {get;set;} // those must be properties, not fields
        public string bbbb {get;set;}
        public string[] ccccArray {get;set;}
        public string[] ddddArray {get;set;}
    }
    ....
    var tmp = new MyWebServiceParameter
    {
         aaaa = "1111", bbbb = "2222",
         ccccArray = new string[] { "....", "...." },
         ddddArray = new string[] { "....", "...." }
    };
