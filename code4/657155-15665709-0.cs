        foreach (Car c in lst[0].Cars)
                    {
                        PropertyInfo[] properties = car.GetType().GetProperties(); 
                        foreach (PropertyInfo item in properties)
                        {
                            string propertyName = item.Name;
                        }
                    }
