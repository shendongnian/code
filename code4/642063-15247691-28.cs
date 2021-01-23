    public static void MyObjectAction(MyObject obj, TextWriter writer)
    {
        // Validate parameters.
        Debug.Assert(obj != null);
        Debug.Assert(writer != null);
    
        // Write.
        writer.WriteLine("MyObject.IntValue: {0}, MyObject.DoubleValue: {1}", 
            obj.IntValue, obj.DoubleValue);
    }
