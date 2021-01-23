    class Program
    {
    	static void Main(string[] args)
    	{
    		ThreadPool.QueueUserWorkItem(LoadAsync);
    
    		Console.WriteLine("waiting");
    		Console.ReadKey();
    	}
    
    	static void LoadAsync(object state)
    	{
    		XDocument document = XDocument.Load("https://dl.dropboxusercontent.com/u/1323651/xml_test.txt");
    
    		DownloadedHandler(document);
    	}
    
    	static void DownloadedHandler(XDocument doc)
    	{
    		Console.WriteLine(doc.ToString());
    	}
    }
