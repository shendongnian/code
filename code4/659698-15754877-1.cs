    private static void Process(StreamWriter outFile, List<Assembly> failedAssemblies)
    {
    	int MAXLIMIT = 2000;
    	string command = "mstest.exe ";
    	string testcontainer = " /testcontainer:";
    	List<string> testContainerAssemblies = new List<string>(4);
    	int sum = 0;
    
    	outFile.WriteLine("SET Path=%MsTestPath%");
    
    
    	var failedAssemblyCollections = (from x in failedAssemblies
    									 group x by x.AssemblyName into g
    									 select new
    									 {
    										 AssemblyNames = g.Key,										 
    										 FullyQualifiedTestMethods = g.Select(i => " /test:" + i.NameSpaceName + "." + i.ClassName + "." + i.FunctionName),
    										 FullyQualifiedTestMethodsLen = g.Select(i => Convert.ToString(" /test:" + i.NameSpaceName + "." + i.ClassName + "." + i.FunctionName).Length)
    									 });
    
    		foreach (var item in failedAssemblyCollections)
    		{
    			var assemblyNames = item.AssemblyNames;
    			var methodsLengths = item.FullyQualifiedTestMethodsLen.ToList();
    			var flag = true;
    			int counter = 0;
    
    			//write for the very first time
    			if (flag)
    			{
    				Write(outFile, ref command, testcontainer, assemblyNames);
    				flag = false;
    			}
    
    
    			for (int i = 0; i < methodsLengths.Count; i++)
    			{
    				sum += methodsLengths[i];
    
    				if (sum <= MAXLIMIT)
    				{
    					command += item.FullyQualifiedTestMethods.ToList()[i];
    
    					//this will execute when a long command is splitted and is written in new trx files
    					if (flag)
    					{
    						counter++;
    						Write(outFile, ref command, testcontainer, assemblyNames);
    						flag = false;
    					}
    				}
    
    
    				//if the value crosses max limit
    				//write the current output
    				//then reset variables to original 
    				if (sum >= MAXLIMIT)
    				{
    					outFile.Write(command);
    					sum = 0;
    					flag = true;
    					i--;
    				}
    			}
    			outFile.Write(command);
    
    		}
    
    }
    
    private static void Write(StreamWriter outFile, ref string command, string testcontainer, string assemblyNames)
    {
    	outFile.WriteLine(' ');
    	command = "mstest.exe ";
    	command += testcontainer + "\\" + assemblyNames + " ";	
    	command += " /runconfig:";
    	command += " /detail:owner";
    	command += " /detail:duration";
    	command += " /detail:description";
    
    	command += " /unique ";
    
    }
