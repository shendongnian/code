            List<object> collection = new List<object>
            {
                new { Age1 = 1, Name = "Mr. Someone" } 
            };            
            // you can use reflection
            object anonymous = collection.First();
            var parameterInfo = anonymous.GetType().GetProperty("Name");
            string name1 = (string)parameterInfo.GetValue(anonymous, null);
            // another way
            dynamic dynamicObject = collection.First();
            string name2 dynamicObject.Name;
