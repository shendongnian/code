    using (var fileStream = new FileStream("TestFormatter.dat", FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                var myObject = binaryFormatter.Deserialize(fileStream);
                var objectProperties = myObject.GetType().GetProperties();
                foreach (var property in objectProperties)
                {
                    var propertyTypeName = property.PropertyType.Name; //This will tell you the property Type Name. I.e. string, int64 (long)
                }                
            }
    
