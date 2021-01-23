    class Subscriber
    {
        public void SomeMethod(object sender, EventArgs e)
        {
        }
    }
    static class Serialize
    {
        public static void Test()
        {
            var objWithEvent = new ClassWithEvent();
            var subscriber1 = new Subscriber();
            var subscriber2 = new Subscriber();
            objWithEvent.SomeEvent += subscriber1.SomeMethod;
            objWithEvent.SomeEvent += subscriber2.SomeMethod;
            Delegate[] eventInfo = objWithEvent.GetSomeEventInvocationList();
            foreach (Delegate d in eventInfo) {
                Console.WriteLine("Target = {0},   Method = {1}", 
                                  d.Target, d.Method.Name);
            }
        }
    }
