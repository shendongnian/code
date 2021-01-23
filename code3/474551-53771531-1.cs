     public class Variable
        {
            public static string StaticName = "Sophia ";
            public string nonStName = "Jenna ";
            public void test()
            {
                StaticName = StaticName + " Lauren"; 
                Console.WriteLine("  static ={0}",StaticName);
                nonStName = nonStName + "Bean ";
                Console.WriteLine("  NeStatic neSt={0}", nonStName);
    
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Variable var = new Variable();
                var.test();
                Variable var1 = new Variable();
                var1.test();
                Variable var2 = new Variable();
                var2.test();
                Console.ReadKey();
    
            }
        }
    
    Output 
      static =Sophia  Lauren
      NeStatic neSt=Jenna Bean
      static =Sophia  Lauren Lauren
      NeStatic neSt=Jenna Bean
      static =Sophia  Lauren Lauren Lauren
      NeStatic neSt=Jenna Bean
