            string myObjectString = "MyObject, SetWidth, int, 10, 0, 1";
            var info = myObjectString.Split(',');
            string objectName = info[0].Trim();
            string propertyName = info[1].Trim();
            string defaultValue = info[3].Trim();
            //find the type
            Type objectType = Assembly.GetExecutingAssembly().GetTypes().Where(t=>t.Name.EndsWith(objectName)).Single();//might want to redirect to proper assembly
            //create an instance
            object theObject = Activator.CreateInstance(objectType);
            //set the property
            PropertyInfo pi = objectType.GetProperty(propertyName);
            object valueToBeSet = Convert.ChangeType(defaultValue, pi.PropertyType);
            pi.SetValue(theObject, valueToBeSet, null);
            
            return theObject;
