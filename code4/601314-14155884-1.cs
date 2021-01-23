	class DynamicTest : DynamicObject
    {
        public DynamicTest(string xyz)
        {
            _xyz = xyz;
        }
 		private string _xyz;
		
		public override bool TryConvert(ConvertBinder binder, out Object result)
		{
			Console.WriteLine ("TryConvert was called");
			Console.WriteLine ("Is explicit: "+binder.Explicit);
			if(binder.Type == typeof(bool))
			{
				result = true;
				return true;
			}
			else if(binder.Type == typeof(string))
			{	
				result = _xyz;
				return true;
			}
			
			result = null;
			return false;
		}
		
		public override string ToString()
		{
			return _xyz;
		}
	}
