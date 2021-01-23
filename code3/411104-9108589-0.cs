    using System.IO;
    
    namespace ConsoleApplication1
    {
    	 class Program
    	 {
    		  static void Main(string[] args)
    		  {
    				string[] parts;
    				//string[] lines = System.IO.File.ReadAllLines(@"somefile.csv");
    				string[] lines = new string[] { 
    					 "a1,a2,a3,a4,type", 
    					 "22,33,44,55,t1", 
    					 "222,333,444,555,t2", 
    					 "2222,3333,4444,5555,t3" };
    				int lineno = 1;
    
    				string path = @"c:\output.csv";
    				using (TextWriter writer = File.CreateText(path))
    				{
    					 foreach (string line in lines)
    					 {
    						  if (lineno > 1)
    						  {
    								parts = line.Split(',');
    								for (int a = 0; a < parts.Length - 1; a++)
    									 writer.WriteLine(lineno.ToString() + "," + (a+1).ToString() + "," + parts[a]);
    						  }
    						  lineno++;
    					 }
    				}
    		  }
    	 }
    }
