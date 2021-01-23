    class Program
    {
    	static void Main(string[] args)
    	{
    		// Create a main window GUI
    		Form1 form1 = new Form1();
    
    		// Create a thread to listen concurrently to the GUI thread
    		Thread listenerThread = new Thread(new ParameterizedThreadStart(Listener));
    		listenerThread.IsBackground = true;
    		listenerThread.Start(form1);
    
    		// Run the form
    		System.Windows.Forms.Application.Run(form1);
    	}
    
    	static void Listener(object formObject)
    	{
    		Form1 form = (Form1)formObject;
    
    		// Do whatever we need to do
    		while (true)
    		{
    			Thread.Sleep(1000);
    			form.AddLineToTextBox("Hello");
    		}
    	}
    }
