        public static void MyMethod (string p1, string p2)
    {
       MyMthod(p1, p2, "", "");
    }
    
    public static void MyMethod (string p1, string p2, string p3, string p4)
    {
       if(p3 has a value but p4 is missing the value)
        throw new Exception("p4 is required");
    }
