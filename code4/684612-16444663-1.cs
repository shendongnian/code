    MyClass myClass = new MyClass();
    Timer timer1 = new Timer();
    timer1.Tick += myClass.TimerCallback; // subscribe to other's class method
    timer1.Interval = 1000;
    timer1.Start();
    public class MyClass
    {
        public void TimerCallback(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Timer Called by: " + sender);
        }
    }
