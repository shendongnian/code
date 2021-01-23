    class MyClass
    {
        public event EventHandler<MyCustomEventArgs> MyEvent;
        public void MyMethod(int myNumber)
        {
            Console.WriteLine(myNumber);
            if (myNumber == 7)
            {
                MyEvent.Invoke(null, new MyCustomEventArgs() { Foo = "Bar" });
            }
        }
    }
    class MyCustomEventArgs : EventArgs
    {
        public string Foo { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.MyEvent += new EventHandler<MyCustomEventArgs>(myClass_MyEvent);
            for (int i = 0; i < 9; i++)
            {
                myClass.MyMethod(i);
            }
        }
        //This is the method signature that you need to use to handle the event
        static void myClass_MyEvent(object sender, MyCustomEventArgs e)
        {
            Console.WriteLine(e.Foo); // prints "Bar"
            //Do Stuff
        }
        //If you need to handle more than one type of custom event args
        static void myClass_MyEvent<T>(object sender, T e) where T : EventArgs
        {
            //Do Stuff
        }
    }
