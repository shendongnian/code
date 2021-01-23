    void Main()
    {
    	new A<string>().Process("Hello");
    }
    
    public class A<T>
    {
    	public void Process(T item) { Console.WriteLine("T"); }
    	public void Process(string item) { Console.WriteLine("string"); }
    }
    // Output: string
