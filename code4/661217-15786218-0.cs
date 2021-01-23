    static class Program
    {
        static void Main()
        {
            var c = new MyClass();
            c.MyObj = new SecClass();
            c.Register();
            c.MyObj.Noti = !c.MyObj.Noti;
        }
    }
