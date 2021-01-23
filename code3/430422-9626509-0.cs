    using System;
    
    namespace Test
    {
        class Program
        {
    		private object _data;
    
            static void Main(string[] args)
            {
    			new Program().EntryPoint();
            }
    
    		public void EntryPoint()
    		{
    			GetData(typeof(string), "Test");
    			Console.WriteLine(_data);
    		}
    
    		public void GetData(Type myType, string csvPath)
    		{
    			var engine = new FileHelperEngine(myType, csvPath);
    
    			// This is the line that does it.
    			_data = Convert.ChangeType(engine.ReadFile(csvPath), myType);
    		}
    
    		private class FileHelperEngine
    		{
    			public string Value { get; set; }
    			public FileHelperEngine(Type t, string value) { Value = value.ToString(); }
    
    			public string ReadFile(string path) { return Value; }
    		}
        }
    }
