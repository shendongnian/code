    public class ZeroObject
    {
        //Properties
        ZeroObject ReferenceObject { get; set; }
    }
    
    ZeroObject A = new ZeroObject("A");
    ZeroObject B = new ZeroObject("B");
    
    A.ReferenceObject = B;
