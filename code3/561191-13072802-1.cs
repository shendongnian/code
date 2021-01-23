    public class Test
    {
    	public string Prop { get; set; }
    }
	Test t = new Test();
	var propInfo = GetPropertyInfo(() => t.Prop);
	Console.WriteLine(propInfo.Name + " -> " + propInfo.PropertyType); //Prop -> System.String
