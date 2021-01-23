    public class TestClass
    {
         public static string Text1 { get; set; }
         public string Text2 { get; set; }
         public void WriteText1()
         {
             Console.WriteLine(TestClass.Text1);
         }
         public void WriteText2()
         {
             Console.WriteLine(this.Text2);
         }
    }
    public class Program
    {
       public static void Main(string[] args)
       {
           TestClass class1 = new TestClass;
           TestClass.Text1 = "Some Text";
           class1.Text2 = "More Text";
           
           class1.WriteText1();
           class1.WriteText2();
           TestClass class2 = new TestClass;
           TestClass.Text1 = "Another Text";
           class2.Text2 = "And a fourth text";
           
           class2.WriteText1();
           class2.WriteText2();
           
           class1.WriteText1();
       }
    }
