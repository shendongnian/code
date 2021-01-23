    public static void SearchFilesRecursivAndPrintOut(string root, string pattern) {
      //Console.WriteLine(root);
      try{
        var childDireactory = Directory.EnumerateDirectories(root);
        var files = Directory.EnumerateFiles(root, pattern);
    
        foreach (var file in files) {
    	  Console.WriteLine(System.IO.Path.GetDirectoryName(file));
        }  
    
        foreach (var dir in childDireactory){
    	    SearchRecursiv(dir, pattern);
    	}
      }
      catch(Exception exception){
        Console.WriteLine(exception);
      }
    }
