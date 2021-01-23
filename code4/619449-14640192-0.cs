            IEnumerable<object> uncknownObject;
            uncknownObject = new ObservableCollection<Person>();
            
            var observCol = uncknownObject.GetType();
            var x = ((dynamic) observCol).UnderlyingSystemType.GetGenericArguments()[0];
            //var y = observCol.GetProperty("GenericTypeArguments");
            var instance = (Person)Activator.CreateInstance(x);
            Console.WriteLine(instance.Name); // Print Antonio!!!
