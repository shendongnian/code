    class test{
            static void Main(string[] args)
            {
                Value i = new Value(5);
                Value a = i;
                i.number += 1;
                Console.WriteLine(i.number);
                Console.WriteLine(a.number);
            }
     }
     public class Value
     {
            public Value(int x){number = x;}
            public int number { set; get; }
     }
