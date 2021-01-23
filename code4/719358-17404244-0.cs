    public static void TestRefType()
    {
    SampleRefType rt = new SampleRefType();
    rt.value = 44;
    ModifyObject(rt);
    System.Console.WriteLine(rt.value);
    }
