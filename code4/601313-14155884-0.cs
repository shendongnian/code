	class DynamicTest : DynamicObject
    {
        public DynamicTest(string xyz)
        {
            _xyz = xyz;
        }
 		private string _xyz;
        
		
		public static implicit operator bool(DynamicTest m) 
		{
			return !string.IsNullOrEmpty(m._xyz);
		}
        
	}
