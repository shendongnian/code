    public class Test
    {
        public int a { get; set; }
        public int b { get; set; }
    
        public Test(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    
        public static Test operator +(Test first, Test second)
        {
            return new Test(first.a * second.a
                , first.b * second.b);
        }
    
        public override string ToString()
        {
            return a.ToString() + " " + b.ToString();
        }
    
        public void Testa()
        {
            Test t = new Test(5, 5);
            Test t2 = new Test(2, 6);
            Console.WriteLine(t + t2);
        }
    }
