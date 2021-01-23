    void Main()
    {
        Func<int, int, string> tfunc = null;
        tfunc += Add; // bind first method
        tfunc += Sub; // bind second method 
    
        Console.WriteLine(tfunc(2, 2));
    }
    
    private string Add(int a, int b)
    {
        Console.WriteLine("Inside Add");
        return "Add: " + (a + b).ToString();
    }
    
    private string Sub(int a, int b)
    {
        Console.WriteLine("Inside Sub");
        return "Sub: " + (a - b).ToString();
    }
