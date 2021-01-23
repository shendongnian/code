    void Main()
    {
        var a = new A{I = 1};
        var b = new B{I = 1};
        var propertyList = new Dictionary<string, dynamic>();
        propertyList.Add("a", a);
        propertyList.Add("b", b);
        a.I = 2;
        b.I = 2;
        foreach (var value in propertyList.Values)
        {
            Console.WriteLine(value.I);
        }
        // Output:
        //  2
        //  1
    }
    
    public class A{public int I{get;set;}}
    public struct B{public int I{get;set;}}
