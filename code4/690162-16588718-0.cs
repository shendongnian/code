    static void Main(string[] args)
    		{
    			string[] array = new[] { "ab", "ab", "ab", "free", "free", "hello" };
    			Console.WriteLine(string.Join(", ", array));
    
    			ArrayItem[] boxed = Box(array);
    			ShuffleArray(boxed);
    
    			Console.WriteLine(string.Join(", ", boxed.Select(x => x.ToString()).ToArray()));
    
    			string[] unboxed = Unbox(boxed);
    
    			Console.WriteLine(string.Join(", ", unboxed));
    
    			Console.ReadKey();
    		}
    
    		internal sealed class ArrayItem
    		{
    			public string Value { get; private set; }
    			public int Count { get; set; }
    
    			public ArrayItem(string value)
    			{
    				Value = value;
    				Count = 1;
    			}
    
    			public IEnumerable<string> Unbox()
    			{
    				string[] result = new string[Count];
    
    				for (int i = 0; i < Count; i++)
    				{
    					result[i] = Value;
    				}
    
    				return result;
    			}
    
    			public override string ToString()
    			{
    				return string.Format("{0} - {1}", Value, Count);
    			}
    		}
    
    		private static ArrayItem[] Box(string[] array)
   		{ 
    			var list = new List<ArrayItem>();
    			foreach (string s in array)
    			{
    				if (list.Count == 0)
    				{
    					list.Add(new ArrayItem(s));
    					continue;
    				}
    
    				var last = list[list.Count - 1];
    				if (s == last.Value)
    				{
    					last.Count += 1;
    					continue;
    				}
    				else
    				{
    					list.Add(new ArrayItem(s));
    					continue;
    				}
    			}
    
    			return list.ToArray();
    		}
    
    		private static string[] Unbox(ArrayItem[] array)
    		{
    			var list = new List<string>();
    			foreach (var item in array)
    			{
    				list.AddRange(item.Unbox());
    			}
    
    			return list.ToArray();
    		}
    
    		private static void ShuffleArray(ArrayItem[] array)
    		{
    			Random r = new Random();
    
    			for (int i = 0; i < array.Length; i++)
    			{
    				int a = r.Next(0, array.Length);
    				int b = r.Next(0, array.Length);
    
    				SwapItems(array, a, b);
    			}
    		}
    
    		private static void SwapItems(ArrayItem[] array, int a, int b)
    		{
    			var temp = array[b];
    			array[b] = array[a];
    			array[a] = temp;
    		}
