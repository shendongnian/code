    public class MyThread
    {
        public int A;
        public CallerType ParentThis;
        public void Thread1()
        {
            // you can use this.A from here
            // You can use ParentThis.Something to access the caller
        }
    }
    var myt = new MyThread();
    myt.A = 100;
    myt.ParentThis = this;
    var t = new Thread(myt.Thread1)
    t.Start();
