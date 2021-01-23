    public int numCounter;
    private delegate void MyMethodDelegate(int numCounter);
    private void button2_Click(object sender, EventArgs e)
    {
     for (numCounter = 0; numCounter < 10; numCounter++)
     {
      MyMethodDelegate myDelegate = new MyMethodDelegate(myMethod);
      myDelegate.BeginInvoke(numCounter, myMethodDone, myDelegate);
     }
    }
    public void myMethod(int numCounter)
    {
     Console.WriteLine(numCounter);
    }
    public void myMethodDone(IAsyncResult result)
    {
     MyMethodDelegate myDelegate = result.AsyncState as MyMethodDelegate;
     if (myDelegate != null)
     {
      myDelegate.EndInvoke(result);
     }
    }
