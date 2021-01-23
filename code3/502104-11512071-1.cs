    Type _type = typeof(int);
    Type listType = typeof(List<>).MakeGenericType(_type); 
    dynamic list = Activator.CreateInstance(listType); 
    list.Add(1);   
    list.AddRange(new int[] {0, 1, 2, 3});  
