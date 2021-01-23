    interface Iobject1
    {
        int P1 { set; get; }
        int P2 { set; get; }
        int P3 { set; get; } 
    }
    interface Iobject2
    {
        int P3{set; get;}
        string P4{set; get;}
        string P5{set; get;}
    }
    class clsMain : Iobject1, Iobject2
    {
        public int P1{set; get;}
        public int P2{set; get;}
        public int P3{set; get;}
        public string P4{set; get;}
        public string P5{set; get;}
    }
