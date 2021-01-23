    public class Test{
     public Test(){
     	Console.WriteLine("Defaul ctor");
     }
     
     public Test(int i){
     	Console.WriteLine("Test(int)");
     }
     
     public  Test(int i, string s){
     	Console.WriteLine("Test(int, string)");
     }
    }
    public static void Main()
    {
    	var o1 = Activator.CreateInstance(typeof(Test));
    	var o2 = Activator.CreateInstance(typeof(Test), 1);
    	var o3 = Activator.CreateInstance(typeof(Test), 1, "test");
    }
