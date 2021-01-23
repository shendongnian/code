    using System;
    using System.Linq;
    
    namespace ConsoleApplication1 {
    	internal class Program {
    		private static void Main() {
    			var MD = new double [] {0, 0, 0, 0, 0};
    			var result = MD.Select(n => n*100/MD.Sum()).ToArray();
    			foreach (var item in result) {
    				Console.WriteLine(item);
    			}
    			Console.ReadLine();
    		}
    	}
    }
