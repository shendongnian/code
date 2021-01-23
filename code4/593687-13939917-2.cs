	public struct Container {
		public object Value { get; set; }
		public bool IsNull { get { return Value == null; } }
		public static bool operator ==(Container x, object y) { return x.Equals(y); }
		public static bool operator !=(Container x, object y) { return !x.Equals(y); }
		public override bool Equals(object obj) {
			if (obj is Container)
				return Value == ((Container)obj).Value;
			return Value == obj;
		}
		public override int GetHashCode() { return Value == null ? 0 : Value.GetHashCode(); }
	}
    ////---------Test----------
    var x = new Container { Value = null };
    var y = new Container { Value = "hi" };
    var z = new Container { Value = null };
    Print(x == null); //true 
    Print(x == y);    //false
    Print(x == z);    //true
