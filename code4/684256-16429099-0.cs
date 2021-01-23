    Class1{
        public Class2 class2 { get; set; }
        public int Var { get; set; }
        public int InnerVar { get { return class2.Var; } }
    }
    
    Class2{
        public int Var { get; set; }
    }
