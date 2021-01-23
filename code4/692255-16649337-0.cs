    public static void printAllLines()
    {
        btnPrint.Enabled = false;      
        Thread t = new Thread(sendToPrinter);            
        t.Start();//starts the thread
    }
    public static void sendToPrinter()
    {
        int count = myOutputStringCollection.Count;
        string[] myArray = new string[count];
        myOutputStringCollection.CopyTo(myArray, 0);
        for (int i = 0; i < count; i++)
        {
             SendStringToPrinter(myArray[i]); // no need for ToString() as it's already a string
        }
    
        // re-enable print button by marshalling to UI thread
        this.Invoke(new MethodInvoker(delegate() 
        { 
             btnPrint.Enabled = true;
        }));     
    }
