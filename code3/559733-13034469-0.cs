    Class A
    {
        public string Rawr {get; set;}
    }
    
    Class B : A
    {
        public string Rawr2 { get { return Rawr; } set { Rawr = value; } }
    }
    
    var b = new B();
    b.Rawr = "asdf"
    
    Console.WriteLine(b.Rawr2);
