    public class ClassBToCAdapter : IClassC
	{
		 private ClassB adaptee;
		 public ClassBToCAdapter(ClassB classB)
		 {
			this.adaptee = classB
		 }
		 
		 public int IntProperty
		 {
			get { return adaptee.IntProperty; }
			set { adaptee.IntProperty = value; }
		 }
	}
