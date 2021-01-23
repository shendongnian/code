	public class Box {
		public static bool ItemsEqual(object x, object y) {
			object xval, yval;
			xval = x is Box ? (x as Box).Value : x;
			yval = y is Box ? (y as Box).Value : y;
			return xval == yval;
		}
		public object Value { get; set; }
		public bool IsNull { get { return Value == null; } }
		public static bool operator ==(Box x, object y) { return ItemsEqual(x, y); }
		public static bool operator !=(Box x, object y) { return !ItemsEqual(x, y); }
		public override bool Equals(object obj) { return ItemsEqual(this, obj); }
		public override int GetHashCode() { return Value == null ? 0 : Value.GetHashCode(); }
	}
    ////---------Test----------
    object n = null;
    Box w = null;
    Box x = new Box { Value = null };
    Box y = new Box { Value = "hi" };
    Box z = new Box { Value = "hi" };
    Print(w == null);  //true (uses overridden '==' because w is defined as a Box)
    Print(w == n);     //true
    Print(x == w);     //true 
    Print(x == null);  //true 
    Print(x == n);     //true 
    Print(w == y);    //false
    Print(x == y);    //false
    Print(y == z);    //true (actual ref's differ, but values are ==)
