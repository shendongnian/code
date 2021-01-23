	public class Entry
	{
		private ObjA oA;
		private ObjB[] listB;
		public int PropA1 {get {return {oA.Prop1}} set {oA.Prop1 = value;}}
		public int PropA2 {get {return {oA.Prop2}} set {oA.Prop1 = value;}}
		public EntryProperties propsA3;
		
		public Entry() 
		{
			propsA3 = new EntryProperties(this);
		}
	  
		public class EntryProperties 
		{
			private Entry _entry;
			
			public EntryProperties(Entry entry) {
				_entry = entry;
			}
			
			public int this[int index] {
				get { return _entry.oA.getVal3(_entry.listB[index]); }
				set { _entry.oA.setVal3(_entry.listB[index], value); }
			}
		}
	}
