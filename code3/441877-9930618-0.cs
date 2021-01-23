    public class LCU
    {
        public string Gender {get; set;}
        public string Product {get; set;} 
        public string Category {get; set;}
        public LCU(){}
    }
    
    private static LSU LShoe_UctHandler(string id)
    {
        var lcu = new LCU();
        var s = id.Split('-');
        if (s.length < 2) throw new ArgumentException("id");
        lcu.Category = s[1];
        lcu.Gender = s[0].Substring(0,1);
        lcu.Product = s[0].Substring(1);
        return lcu;
    }
