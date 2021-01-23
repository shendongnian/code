    public static void Main(string[] args)
    		{
    			Console.WriteLine("Hello World!");
    						
    			System.Collections.Generic.HashSet<int> setA= new System.Collections.Generic.HashSet<int>();
    			setA.Add(1);
    			System.Collections.Generic.HashSet<int> setB= new System.Collections.Generic.HashSet<int>();
    			setB.Add(1);
    
    			
    			Console.WriteLine("Equals method returns {0}", setA.Equals(setB));
    			Console.WriteLine("SetEquals method returns {0}", setA.SetEquals(setB));
    			
    			
    			Console.Write("Press any key to continue . . . ");
    			Console.ReadKey(true);
    		}
