    public int numCounter;
    
    private void button2_Click(object sender, EventArgs e)
    {
     for (numCounter = 0; numCounter < 10; numCounter++)
     {
      Thread myThread = new Thread(myMethod);
      myThread.Start(numCounter);
     }
    }
    
    public void myMethod(object numCounter)
    {
     Console.WriteLine(numCounter);
    }
