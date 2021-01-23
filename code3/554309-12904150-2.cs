    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Diagnostics;
    
    namespace ParallelForTiming
    {
    	class Program
    	{		
    		static void Main(string[] args)
    		{
    			var sw = new Stopwatch();
    			var pct = 0.000001;
    			var iter = 20;
    			var time = 20 * 1000 / iter;
    			var p = new ParallelOptions(); p.MaxDegreeOfParallelism = 4;
    
    			var Done = false;
    			Parallel.Invoke(() =>
    			{
    				sw.Start();
    				Parallel.For(0, iter, p, (i) => { Thread.Sleep(time); lock(p) { pct += 1 / (double)iter; }});				
    				sw.Stop(); 
    				Done = true;
    				
    			}, () =>
    			{
    				while (!Done)
    				{
    					Console.WriteLine(Math.Round(pct*100,2) + " : " + ((pct < 0.1) ? "oo" : (sw.ElapsedMilliseconds / pct /1000.0).ToString()));
    					Thread.Sleep(2000);
    				}
    
    			}
    			);
    			Console.WriteLine(Math.Round(pct * 100, 2) + " : " + sw.ElapsedMilliseconds / pct / 1000.0);
    			
    
    			Console.ReadKey();
    		}
    	}
    }
