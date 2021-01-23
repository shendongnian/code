    public Interface IParameters
    {
        string p1 {get; set;}
        char p2 {get; set;}
        double p3 {get; set;}
        bool p4 { get; set; }
        DateTime p5 { get; set; }
    }
    
    public interface MyInterface
    {
        IData GetData(IParameters p);
    }
