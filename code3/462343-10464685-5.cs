    static void Main(string[] args)
    {
    	string[] docs = new string[50000];
    
    	for (int i = 0; i < docs.Length; i++)
    	{
    		docs[i] = "a man a plan a canal panama";
    	}
    
    	// warm up (don't time this)
    	GenerateTermsOriginal(docs);
    	
    	Stopwatch sw = new Stopwatch();
    	sw.Restart();
    	var t1 = GenerateTermsOriginal(docs);
    	sw.Stop();
    	Console.WriteLine(sw.ElapsedMilliseconds + " ms");
    
    	sw.Restart();
    	var t2 = GenerateTermsLinq(docs);
    	sw.Stop();
    	Console.WriteLine(sw.ElapsedMilliseconds + " ms");
    
    	sw.Restart();
    	var t3 = GenerateTermsDictionary(docs);
    	sw.Stop();
    	Console.WriteLine(sw.ElapsedMilliseconds + " ms");
    }
