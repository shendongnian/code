	void Main()
	{
		string nameIdPair = "name1:123\r\nname2:456\r\n";
		
		var strings = nameIdPair.Split(new string[]{ "\r\n", "\r", ":" }, 
                                       StringSplitOptions.RemoveEmptyEntries);
		var structs = strings.Unzip();
		
		structs.Dump();
	}
	
	public struct MyStruct
	{
	    public string Name;
	    public int Id;
	}
		
	static class Helpers
	{
		public static IEnumerable<MyStruct> Unzip(this IEnumerable<string> items)
		{
			using(var en = items.GetEnumerator())
			{
				string name = null;
				
				while(en.MoveNext())
				{
					if(name == null){
						name = en.Current;
					}
					else{
						int id = int.Parse(en.Current);
						yield return new MyStruct{Name = name, Id = id};
						name = null;
					}
				}
			}
			
			yield break;
		}
	}
