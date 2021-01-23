    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var objs = new List<FirstLevel> { new FirstLevel(), new SecondLevel(), new ThirdLevel(), new SecondLevel2() };
                objs.ForEach(o => o.Generate());
                Console.ReadLine();
            }
    
        }
    
        public class FirstLevel
        {
            public virtual void Generate()
            {
                Console.WriteLine("First Level Generate called.");
            }
        }
    
        public class SecondLevel : FirstLevel
        {
            public override void Generate()
            {
                Console.WriteLine("Second Level generate called.");
            }
        }
    
        public class SecondLevel2 : FirstLevel
        {
           
        }
        public class ThirdLevel : SecondLevel
        {
            public override void Generate()
            {
                Console.WriteLine("Third Level genrate.");
            }
        }
    }
