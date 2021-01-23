     foreach (PropertyInfo item in propertyInfos)
                {
                    Object obj = item.GetValue(object,null);
                    if (!obj.GetType().IsValueType)
                    {
                        if (obj.GetType() == typeof(String))
                        {
                            Console.WriteLine(obj.ToString());
                        }
                        else if (obj.GetType() == typeof(List<T>))
                        {
                            //run a loop and print the list
    
                        }
                        else if (obj.GetType().IsArray) // this means its Array
                        {
                            //run a loop to print the array
                        }
                      
                    }
                    else
                    {
                        //its primitive so we will convert to string 
                        Console.WriteLine(obj.ToString());
    
                    }
