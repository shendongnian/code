    using System;
    using System.Windows.Forms;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass1 obj = new MyClass1();
                obj.Method1();
            }
        }
        public class MyClass1
        {
            public void Method1()
            {
                MyClass2 obj = new MyClass2();
                obj.SomethingHappened += somethingHappened;
                obj.Method1();
            }
            private static void somethingHappened(object sender, EventArgs e)
            {
                Console.WriteLine("Something happened!");
            }
        }
        public class MyClass2
        {
            public void Method1()
            {
                MyClass3 obj = new MyClass3();
                obj.SomethingHappened += onSomethingHappened;
                obj.Method1();
            }
            public event EventHandler SomethingHappened;
            private void onSomethingHappened(object sender, EventArgs e)
            {
                var handler = SomethingHappened;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }
        public class MyClass3
        {
            public void Method1()
            {
                onSomethingHappened();
            }
            private void onSomethingHappened()
            {
                var handler = SomethingHappened;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
            public event EventHandler SomethingHappened;
        }
    }
