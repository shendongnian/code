    void Main()
    {
        var s = new MyStruct();
        Test(s);
        Debug.WriteLine(s.Description);
    }
    
    public void Test(IMyInterface i)
    {
        i.Description = "Test";
    }
    
    public interface IMyInterface
    {
        string Description { get; set; }
    }
    
    public struct MyStruct : IMyInterface
    {
        public string Description { get; set; }
    }
