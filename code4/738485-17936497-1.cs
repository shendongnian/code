    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Diagnostics;
    
    namespace FastStringSplit
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			Random rnd = new Random();
    			char delim = ':';
    			int[] sizes = new int[]{1000, 100000, 10000000 };
    			int[] iters = new int[]{10000, 100, 10};
    			Stopwatch sw;
    			
    			List<int> list, result = new List<int>();
    			string str;
    			for(int s=0; s<sizes.Length; s++) {
    				list = new List<int>(sizes[s]);
    				for(int i=0; i<sizes[s]; i++)
    					list.Add (rnd.Next());
    				str = string.Join(":", list);
    				Console.WriteLine(string.Format("\nListSize {0} : StringLen {1}", sizes[s], str.Length));
    				////
    				sw = new Stopwatch();
    				for(int i=0; i<iters[s]; i++) {
    					sw.Start();
    					result = SplitForEach(str, delim);
    					sw.Stop();
    				}
    				Console.WriteLine("SplitForEach" + result.Count + " Time : " + sw.Elapsed.ToString());
    				////
    				sw = new Stopwatch();
    				for(int i=0; i<iters[s]; i++) {
    					sw.Start();
    					result = SplitSelect(str, delim);
    					sw.Stop();
    				}
    				Console.WriteLine("SplitSelect" + result.Count + " Time : " + sw.Elapsed.ToString());
    				////
    				sw = new Stopwatch();
    				for(int i=0; i<iters[s]; i++) {
    					sw.Start();
    					result = ForEachChar(str, delim);
    					sw.Stop();
    				}
    				Console.WriteLine("ForEachChar" + result.Count + " Time : " + sw.Elapsed.ToString());
    				////
    				sw = new Stopwatch();
    				for(int i=0; i<iters[s]; i++) {
    					sw.Start();
    					result = SplitParallelSelect(str, delim);
    					sw.Stop();
    				}
    				Console.WriteLine("SplitParallelSelectr" + result.Count + " Time : " + sw.Elapsed.ToString());
    				////
    				sw = new Stopwatch();
    				for(int i=0; i<iters[s]; i++) {
    					sw.Start();
    					result = ForParallelForEachChar(str, delim);
    					sw.Stop();
    				}
    				Console.WriteLine("ForParallelForEachChar" + result.Count + " Time : " + sw.Elapsed.ToString());
    			}
    		}
    		public static List<int> SplitForEach(string s, char delim) {
    			List<int> result = new List<int>();
    			foreach(string x in s.Split(delim))
    				result.Add(int.Parse (x));
    			return result;
    		}
    		public static List<int> SplitSelect(string s, char delim) {
    			return s.Split(delim)
    				.Select(int.Parse)
    					.ToList();
    		}
    		public static List<int> ForEachChar(string s, char delim) {
    			List<int> result = new List<int>();
    			int start = 0;
    			int end = 0;
    			foreach(char x in s) {
    				if(x == delim || end == s.Length - 1) {
    					if(end == s.Length - 1)
    						end++;
    					result.Add(int.Parse (s.Substring(start, end-start)));
    					start = end + 1;
    				}
    				end++;
    			}
    			return result;
    		}
    		public static List<int> SplitParallelSelect(string s, char delim) {
    			return s.Split(delim)
    				.AsParallel()
    					.Select(int.Parse)
    						.ToList();
    		}
    		public static int NumOfThreads = Environment.ProcessorCount > 2 ? Environment.ProcessorCount : 2;
    		public static List<int> ForParallelForEachChar(string s, char delim) {
    			int chunkSize = (s.Length / NumOfThreads) + 1;
    			ConcurrentBag<int> result = new ConcurrentBag<int>();
    			int[] chunks = new int[NumOfThreads+1];
    			Task[] tasks = new Task[NumOfThreads];
    			for(int x=0; x<NumOfThreads; x++) {
    				int next = chunks[x] + chunkSize;
    				while(next < s.Length) {
    					if(s[next] == delim)
    						break;
    					next++;
    				}
    				//Console.WriteLine(next);
    				chunks[x+1] = Math.Min(next, s.Length);
    				tasks[x] = Task.Factory.StartNew((o) => {
    					int chunkId = (int)o;
    					int start = chunks[chunkId];
    					int end = chunks[chunkId + 1];
    					if(start >= s.Length)
    						return;
    					if(s[start] == delim)
    						start++;
    					//Console.WriteLine(string.Format("{0} {1}", start, end));
    					for(int i = start; i<end; i++) {
    						if(s[i] == delim || i == end-1) {
    							if(i == end-1) 
    								i++;
    							result.Add(int.Parse (s.Substring(start, i-start)));
    							start = i + 1;
    						}
    					}
    				}, x);
    			}
    			Task.WaitAll(tasks);
    			return result.ToList();
    		}
    	}
    }
