    void Main()
    {
    	var source = typeof(Student);
    	
    	var listType = typeof(List<>);
    	var cListType = listType.MakeGenericType(source);
    	var list = (IList)Activator.CreateInstance(cListType);
    	
    	var idProperty = source.GetProperty("id");
    	
    	//add data for demo
    	list.Add(new Student{id = 666});
    	list.Add(new Student{id = 1});
    	list.Add(new Student{id = 1000});
    	
        //sort if id is found
    	if(idProperty != null)
    	{
    		list = list.Cast<object>()
    		           .OrderBy(item => idProperty.GetValue(item))
    				   .ToList();
    	}
    	
    	//printing to show that list is sorted
    	list.Cast<Student>()
    		.ToList()
    		.ForEach(s => Console.WriteLine(s.id));
    }
    
    class Student
    {
    	public int id { get; set; }
    }
