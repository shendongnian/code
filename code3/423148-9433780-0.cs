            string[] propertyLookup = { "Property1", "Property2", "Property3", "Property4", "Property5" };  \\ etc etc
            string[] parsedValues = message.Split(delimiter);
            Foo newFoo = new Foo();
            Type fooType = newFoo.GetType();
            for (int i = 0; i < parsedValues.Count(); i++)
            {
                PropertyInfo prop = fooType.GetProperty(propertyLookup[i]);
                prop.SetValue(newFoo, parsedValues[i], null);
            }
