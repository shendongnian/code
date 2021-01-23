	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	 public class MyMeta : Attribute{
	   public Type SomeType { get; set; }
	   public string PropertyName {get;set;}
	   public PropertyInfo Property { get { return /* get the PropertyInfo with reflection */; } } 
	 }
	public class Example{
	  [MyMeta(SomeType = typeof(SomeOtherClass))]   //is strongly typed and get intellisense support...
	  public string SomeClassProp { get; set; }
	  [MyMeta(SomeType = typeof(SomeOtherClass), PropertyName = "SomeOtherProperty")]
	  public string ClassProp2 { get; set; }
	}
