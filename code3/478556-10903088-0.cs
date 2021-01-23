    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.CurrentTime = DateTime.Now;
            Type t = typeof(MyClass);
            PropertyInfo pi= t.GetProperty("CurrentTime");
            object temp= pi.GetValue(mc, null);
            Console.WriteLine(temp);
            Console.ReadLine();
        }
       
    }
    public class MyClass
    {
        private DateTime? currentTime;
        public DateTime? CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; }
        }
    }
