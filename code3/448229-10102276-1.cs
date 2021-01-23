    class clsMain
    {
        public virtual int P1{set; get;}
        public virtual int P2{set; get;}
        public virtual int P3{set; get;}
        public virtual string P4{set; get;}
        public virtual string P5{set; get;}
    }
    class object1 : clsMain
    {
        public override int P1{set; get;}
        public override int P2{set; get;}
        public override int P3{set; get;}    
    }
    class object2 : clsMain
    {
        public override int P3{set; get;}
        public override string P4{set; get;}
        public override string P5{set; get;}
    }
