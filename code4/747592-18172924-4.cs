    public class MyThread
    {
        public int A;
        public void Thread1()
        {
            // you can use this.A from here
        }
    }
    var myt = new MyThread();
    myt.A = 100;
    var t = new Thread(myt.Thread1)
    t.Start();
