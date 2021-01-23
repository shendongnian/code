    public static void main(string[] args)
    {
    	List<Instance> instancelist = new List<Instance>();
    	
    	System.IO.StreamReader file = new System.IO.StreamReader(@"C......");
    	while (! file.EndOfStream ) // rather than while(true) which never stops
    	{
              // Even if this were in an array, instancelist[i].Instance_name would be a null pointer exception,
              // So we create the instance and then add it to the list
              var instance = new Instance(); 
              instance.Instance_name = file.ReadLine();
              //... etc
    		
              instancelist.Add(instance);
    	}
    }
