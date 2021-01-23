            IEnumerable<Type> propertiesOnOtherFile = new List<Type>(); //from somewhere?
            //Here is the problem
            propertiesOnOtherFile = propertiesOnOtherFile.Where(t =>
                t.GetCustomAttributes(false).Any<dynamic>(ca => 
                !string.IsNullOrEmpty(ca.PropertyName))); 
            
