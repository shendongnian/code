    using System.Threading;    
    static void MessageThread()
    {
        MessageBox.Show("Cols:" + _columns.Length.ToString() + " Line: " + lines[i]);
    }
    static void MyProgram()
    {
        Thread t = new Thread(new ThreadStart(MessageThread));
        t.Start();
    }
