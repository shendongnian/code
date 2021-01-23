    public class MyClass
    {
    	public int? Value;
    }
	List<MyClass> myList = new List<MyClass>()
	{
		new MyClass() { Value = 2},
		new MyClass() { Value = -3},
		new MyClass() { Value = null},
		new MyClass() { Value = 9},
	};
	
	var sorted = myList.OrderBy(entry => entry.Value).ToList();
	
	for (int i = 0; i < sorted.Count; i++)
		Console.WriteLine(sorted[i].Value); //null, -3, 2, 9
